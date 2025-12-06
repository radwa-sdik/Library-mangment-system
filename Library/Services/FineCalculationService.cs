using Library.Data;
using Library.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using static Library.Models.Enums;

namespace Library.Services
{
    public class FineCalculationService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<FineCalculationService> _logger;
        private readonly TimeSpan _interval = TimeSpan.FromHours(24);

        public FineCalculationService(
            IServiceProvider serviceProvider,
            ILogger<FineCalculationService> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Fine Calculation Service started.");

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    await GenerateDailyFines();
                    _logger.LogInformation("Daily fine calculation completed successfully.");
                    await Task.Delay(_interval, stoppingToken);
                }
                catch (OperationCanceledException)
                {
                    _logger.LogInformation("Fine Calculation Service is stopping.");
                    break;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error occurred during daily fine generation. Retrying in 10 minutes.");
                    await Task.Delay(TimeSpan.FromMinutes(10), stoppingToken);
                }
            }
        }

        private async Task GenerateDailyFines()
        {
            using var scope = _serviceProvider.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            var settings = await db.Settings.FirstAsync();

            // Get borrowings that are overdue
            var overdueBorrowings = await db.BorrowingBooks
                .Where(b =>
                    b.ReturnDate == null &&
                    DateTime.Now.Date > b.DueDate.Date)
                .ToListAsync();

            if (!overdueBorrowings.Any())
            {
                _logger.LogInformation("No overdue borrowings found.");
                return;
            }

            _logger.LogInformation("Processing {Count} overdue borrowings.", overdueBorrowings.Count);
            int finesCreated = 0;
            int finesUpdated = 0;

            foreach (var borrowing in overdueBorrowings)
            {
                // Mark as overdue if not already
                if (borrowing.Status != BorrowingStatus.OverDue)
                    borrowing.Status = BorrowingStatus.OverDue;

                // Check if fine already exists for this borrowing
                var existingFine = await db.Fines
                    .FirstOrDefaultAsync(f => f.BorrowingId == borrowing.BorrowingId);

                var daysLate = (DateTime.Now.Date - borrowing.DueDate.Date).Days;
                
                // Only process if at least 1 full day late
                if (daysLate < 1)
                    continue;

                if (existingFine == null)
                {
                    // Create new fine
                    var fine = new Fine
                    {
                        BorrowingId = borrowing.BorrowingId,
                        MemberId = borrowing.MemberId,
                        BorrowingDueDate = borrowing.DueDate,
                        FineDate = DateTime.Now,
                        Amount = daysLate * settings.DailyFineRate,
                        IsPaid = false
                    };

                    await db.Fines.AddAsync(fine);
                    finesCreated++;
                }
                else if (!existingFine.IsPaid)
                {
                    // Update unpaid fine amount (accumulates daily)
                    existingFine.Amount = daysLate * settings.DailyFineRate;
                    finesUpdated++;
                }
                // If paid, don't update
            }

            await db.SaveChangesAsync();
            _logger.LogInformation("Fine processing complete. Created: {Created}, Updated: {Updated}", 
                finesCreated, finesUpdated);
        }
    }
}
