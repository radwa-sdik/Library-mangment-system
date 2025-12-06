using Library.Data;
using Library.DTOs;
using Library.Exstinsions;
using Library.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Library.Models.Enums;

namespace Library.Controllers
{
    /// <summary>
    /// Controller responsible for fine management. Provides endpoints for members to view and pay fines, and for fine calculations.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Member")]
    public class FinesController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        /// <summary>
        /// Initializes a new instance of the FinesController class.
        /// </summary>
        /// <param name="db">Application database context</param>
        public FinesController(ApplicationDbContext db) => _db = db;

        /// <summary>
        /// Retrieves all fines for the authenticated member, calculating new fines for overdue books.
        /// </summary>
        /// <returns>List of member's fines with calculated amounts</returns>
        /// <response code="200">Returns member's fines</response>
        /// <response code="401">User is not authenticated</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> MyFines()
        {
            var memberID = User.GetMemberID();
            var settings = await _db.Settings.FirstAsync();

            var overdueBorrowings = await _db.BorrowingBooks
                .Where(b => b.MemberId == memberID &&
                            b.ReturnDate == null &&
                            b.DueDate < DateTime.Now &&
                            b.Status != BorrowingStatus.OverDue)
                .ToListAsync();

            foreach (var borrowing in overdueBorrowings)
            {
                borrowing.Status = BorrowingStatus.OverDue;
                await CreateFine(borrowing, settings);
            }

            await _db.SaveChangesAsync();

            var fines = await _db.Fines
                .Include(f => f.Borrowing)
                .Where(f => f.MemberId == memberID)
                .Select(f => new FineDTO
                {
                    FineID = f.FineId,
                    LoanID = f.BorrowingId,
                    ISBN = f.Borrowing.ISBN,
                    Amount = f.DaysOverdue * settings.DailyFineRate,
                    FineDate = f.FineDate,
                    isPaid = f.IsPaid,
                    PaidDate = f.PaidDate
                })
                .ToListAsync();

            return Ok(fines);
        }

        /// <summary>
        /// Processes payment for a specific fine.
        /// </summary>
        /// <param name="dto">Payment request containing fine ID</param>
        /// <returns>OK response if successful, NotFound if fine doesn't exist</returns>
        /// <response code="200">Fine paid successfully</response>
        /// <response code="400">Fine already paid or invalid request</response>
        /// <response code="401">User is not authenticated</response>
        /// <response code="404">Fine not found</response>
        [HttpPost("{fineId}/pay")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PayFine([FromRoute] int fineId)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                return BadRequest(new { Errors = errors });
            }

            var fine = await _db.Fines.FindAsync(fineId);
            if (fine == null) 
                return NotFound(new { Message = "Fine not found." });

            if (fine.IsPaid)
                return BadRequest(new { Message = "Fine already paid." });

            fine.IsPaid = true;
            fine.PaidDate = DateTime.Now;

            await _db.SaveChangesAsync();
            return Ok(new { Message = "Payment successful", AmountPaid = fine.Amount });
        }

        /// <summary>
        /// Creates a fine for an overdue borrowing. Internal method used by the system.
        /// </summary>
        /// <param name="borrowing">The overdue borrowing record</param>
        /// <param name="settings">System settings containing daily fine rate</param>
        private async Task CreateFine(BorrowingBook borrowing, Settings settings)
        {
            var existingFine = await _db.Fines
                .AnyAsync(f => f.BorrowingId == borrowing.BorrowingId);

            if (existingFine)
                return;

            var daysLate = (DateTime.Now.Date - borrowing.DueDate.Date).Days;
            
            if (daysLate < 1) 
                return;

            var fine = new Fine
            {
                MemberId = borrowing.MemberId,
                BorrowingId = borrowing.BorrowingId,
                BorrowingDueDate = borrowing.DueDate,
                FineDate = DateTime.Now,
                Amount = daysLate * settings.DailyFineRate,               
                IsPaid = false
            };

            await _db.Fines.AddAsync(fine);
        }
    }
}
