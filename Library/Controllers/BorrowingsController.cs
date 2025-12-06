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
    /// Controller responsible for book borrowing operations. Provides endpoints for members to borrow and return books.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Member")]
    public class BorrowingsController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        /// <summary>
        /// Initializes a new instance of the BorrowingsController class.
        /// </summary>
        /// <param name="db">Application database context</param>
        public BorrowingsController(ApplicationDbContext db) => _db = db;

        /// <summary>
        /// Retrieves borrowing history for the authenticated member.
        /// </summary>
        /// <param name="query">Query parameters for filtering borrowings</param>
        /// <returns>List of borrowings for the current member</returns>
        /// <response code="200">Returns member's borrowing history</response>
        /// <response code="401">User is not authenticated</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetBorrowings([FromQuery] BorrowingQueryDTO query)
        {
            var memberId = User.GetMemberID();

            var borrowings = await _db.BorrowingBooks
                .Include(b => b.Book)
                .Where(b => b.MemberId == memberId)
                .OrderByDescending(b => b.BorrowDate)
                .Select(b => new BorrowingResponseDTO
                {
                    BorrowingId = b.BorrowingId,
                    ISBN = b.ISBN,
                    BookTitle = b.Book.Title,
                    BookAuthor = b.Book.Author,
                    BorrowDate = b.BorrowDate,
                    DueDate = b.DueDate,
                    ReturnDate = b.ReturnDate,
                    Status = b.realStatues.ToString(),
                    DaysBorrowed = b.daysBorrowed,
                    IsOverdue = b.ReturnDate == null && b.DueDate < DateTime.Now
                })
                .ToListAsync();     

            return Ok(borrowings);
        }

        /// <summary>
        /// Allows a member to borrow a book. Handles reservations and availability checks.
        /// </summary>
        /// <param name="dto">Borrow request containing ISBN and number of days</param>
        /// <returns>OK response if successful, BadRequest if book unavailable or status issues</returns>
        /// <response code="200">Book borrowed successfully</response>
        /// <response code="400">Book unavailable, reservation issues, or invalid request</response>
        /// <response code="401">User is not authenticated</response>
        /// <response code="404">Book not found</response>
        [HttpPost("borrow")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> BorrowBook([FromBody] BorrowRequestDTO dto)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                return BadRequest(new { Errors = errors });
            }

            var settings = await _db.Settings.FirstAsync();
            if (dto.numberOfDays <= 0 || dto.numberOfDays > settings.MaxBorrowDays)
                return BadRequest(new { Message = $"Number of days must be between 1 and {settings.MaxBorrowDays}." });

            var book = await _db.Books
                .Include(b => b.Reservations)
                .FirstOrDefaultAsync(b => b.ISBN == dto.ISBN);

            if (book == null)
                return NotFound(new { Message = "Book not found." });

            var memberId = User.GetMemberID();

            // Check for ANY active reservation (Reserved or Waiting)
            var existingReservation = book.Reservations
                .FirstOrDefault(r => r.MemberId == memberId &&
                                   (r.Status == ReservationStatus.Reserved ||
                                    r.Status == ReservationStatus.Waiting));

            if(existingReservation != null && existingReservation.Status == ReservationStatus.Reserved && DateTime.Now > existingReservation.ExpiryDate)
            {
                existingReservation.Status = ReservationStatus.Expired;
                book.AvailableCopies++; //Release the reserved copy
                await _db.SaveChangesAsync();
                existingReservation = null; //Treat as no existing reservation
            }

            if (existingReservation != null)
            {
                if (existingReservation.Status == ReservationStatus.Waiting)
                    return BadRequest(new { Message = "Book not yet available for you. You're still in the queue." });

                existingReservation.Status = ReservationStatus.Completed;
            }
            else
            {
                if (!book.isAvaliable)
                    return BadRequest(new { Message = "No available copies to borrow." });

                book.AvailableCopies--;
            }

            var loan = new BorrowingBook
            {
                MemberId = memberId,
                ISBN = dto.ISBN,
                BorrowDate = DateTime.Now,
                daysBorrowed = dto.numberOfDays,
                DueDate = DateTime.Now.AddDays(dto.numberOfDays),
                Status = BorrowingStatus.Borrowed
            };

            await _db.BorrowingBooks.AddAsync(loan);
            await _db.SaveChangesAsync();

            return Ok(new { Message = "Borrow successful", BorrowingId = loan.BorrowingId });
        }

        /// <summary>
        /// Allows a member to return a borrowed book.
        /// </summary>
        /// <param name="id">loan(borrowing) ID</param>
        /// <returns>OK response if successful, BadRequest if return is invalid</returns>
        /// <response code="200">Book returned successfully</response>
        /// <response code="400">Invalid return or pending fines exist</response>
        /// <response code="401">User is not authenticated</response>
        [HttpPost("{borrowingId}/return")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> ReturnBook([FromRoute] int borrowingId)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                return BadRequest(new { Errors = errors });
            }

            var loan = await _db.BorrowingBooks.FindAsync(borrowingId);
            if (loan == null || loan.ReturnDate != null)
                return BadRequest(new { Message = "Invalid return." });

            var fines = await _db.Fines.Where(f => f.BorrowingId == borrowingId && !f.IsPaid).AnyAsync();
            if (fines)
                return BadRequest(new { Message = "Cannot return book with pending fines." });

            loan.ReturnDate = DateTime.Now;
            loan.Status = BorrowingStatus.Returned;

            var nextReservation = await _db.Reservations
                .Where(r => r.ISBN == loan.ISBN &&
                            r.Status == ReservationStatus.Waiting &&
                            r.ExpiryDate == null)
                .OrderBy(r => r.Date)
                .FirstOrDefaultAsync();

            if (nextReservation != null)
            {
                var settings = await _db.Settings.FirstAsync();
                nextReservation.ExpiryDate = DateTime.Now.AddDays(settings.ReservationExpiryDays);
                nextReservation.Status = ReservationStatus.Reserved;
            }
            else
            {
                var book = await _db.Books.FindAsync(loan.ISBN);
                book.AvailableCopies++;
            }          

            await _db.SaveChangesAsync();
            return Ok(new { Message = "Return successful" });
        }
    }
}
