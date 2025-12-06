using Library.Data;
using Microsoft.EntityFrameworkCore;
using static Library.Models.Enums;

namespace Library.Services
{
    public class ReservationCleanupService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly TimeSpan _interval = TimeSpan.FromMinutes(30); // Run every 30 minutes

        public ReservationCleanupService(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    await CleanupExpiredReservations();
                    await Task.Delay(_interval, stoppingToken);
                }
                catch (Exception ex)
                {
                    await Task.Delay(TimeSpan.FromMinutes(5), stoppingToken); // Wait before retrying
                }
            }

        }

        private async Task CleanupExpiredReservations()
        {
            using var scope = _serviceProvider.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            
            var settings = await db.Settings.FirstAsync(); // ✅ Fetch once

            var expiredReservations = await db.Reservations
                .Include(r => r.Book)
                .Where(r => r.Status == ReservationStatus.Reserved &&
                            r.ExpiryDate < DateTime.Now)
                .ToListAsync();

            if (expiredReservations.Any())
            {
                foreach (var reservation in expiredReservations)
                {
                    reservation.Status = ReservationStatus.Expired;

                    var nextReservation = await db.Reservations
                        .Where(r => r.ISBN == reservation.ISBN &&
                                    r.Status == ReservationStatus.Waiting)
                        .OrderBy(r => r.Date)
                        .FirstOrDefaultAsync();

                    if (nextReservation != null)
                    {
                        nextReservation.ExpiryDate = DateTime.Now.AddDays(settings.ReservationExpiryDays);
                        nextReservation.Status = ReservationStatus.Reserved;
                    }
                    else
                    {
                        reservation.Book.AvailableCopies++;
                    }
                }

                await db.SaveChangesAsync();
            }
        }
    }
}