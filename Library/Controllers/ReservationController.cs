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
    /// Controller responsible for book reservation operations. Provides endpoints for members to reserve and manage book reservations.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Member")]
    public class ReservationsController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        /// <summary>
        /// Initializes a new instance of the ReservationsController class.
        /// </summary>
        /// <param name="db">Application database context</param>
        public ReservationsController(ApplicationDbContext db) => _db = db;

        /// <summary>
        /// Retrieves all reservations for the authenticated member.
        /// </summary>
        /// <returns>List of member's reservations</returns>
        /// <response code="200">Returns member's reservations</response>
        /// <response code="401">User is not authenticated</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetMyReservations()
        {
            var memberId = User.GetMemberID();

            var result = await _db.Reservations
                .Include(r => r.Book)
                .Where(r => r.MemberId == memberId)
                .Select(r => new MemberReservationDTO
                {
                    ReservationID = r.ReservationId,
                    ISBN = r.ISBN,
                    BookTitle = r.Book.Title,
                    Date = r.Date,
                    ExpiryDate = r.ExpiryDate,
                    Status = r.Status.ToString()
                }).ToListAsync();

            return Ok(result);
        }

        /// <summary>
        /// Reserves a book for the authenticated member.
        /// </summary>
        /// <param name="ISBN">The ISBN of the book to reserve</param>
        /// <returns>OK response if successful with reservation status</returns>
        /// <response code="200">Book reserved successfully</response>
        /// <response code="400">Book already reserved by member or invalid request</response>
        /// <response code="401">User is not authenticated</response>
        /// <response code="404">Book not found</response>
        [HttpPost("{ISBN}/reserve")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ReserveBook(string ISBN)
        {
            if (string.IsNullOrEmpty(ISBN))
                return BadRequest(new { Message = "ISBN is required." });

            var book = await _db.Books
                .Include(b => b.Reservations)
                .Include(b => b.Borrowings)
                .FirstOrDefaultAsync(b => b.ISBN == ISBN);

            if (book == null)
                return NotFound(new { Message = "Book not found." });

            var memberId = User.GetMemberID();
            var existingReservation = book.Reservations
                .FirstOrDefault(r => r.MemberId == memberId &&
                (r.Status == ReservationStatus.Waiting || r.Status == ReservationStatus.Reserved));

            if (existingReservation != null)
                return BadRequest(new { Message = "You already have an active reservation for this book." });

            var settings = await _db.Settings.FirstOrDefaultAsync();

            var isAvailable = book.isAvaliable;

            var reservation = new Reservation
            {
                MemberId = memberId,
                ISBN = ISBN,
                Date = DateTime.Now,
                Status = isAvailable ? ReservationStatus.Reserved : ReservationStatus.Waiting,
                ExpiryDate = isAvailable ? DateTime.Now.AddDays(settings.ReservationExpiryDays) : null,
            };

            if (isAvailable)
                book.AvailableCopies--;

            await _db.Reservations.AddAsync(reservation);
            await _db.SaveChangesAsync();
            
            var message = isAvailable ? "Book reserved - pick up before expiry" : "Added to waiting queue";
            return Ok(new { Message = message, ReservationID = reservation.ReservationId });
        }

        /// <summary>
        /// Cancels an existing reservation for the authenticated member.
        /// </summary>
        /// <param name="id">The ID of the reservation to cancel</param>
        /// <returns>OK response if successful, NotFound if reservation doesn't exist</returns>
        /// <response code="200">Reservation canceled successfully</response>
        /// <response code="401">User is not authenticated</response>
        /// <response code="403">User does not own this reservation</response>
        /// <response code="404">Reservation not found</response>
        [HttpPost("{id:int}/cancel")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CancelReservation(int id)
        {
            var memberId = User.GetMemberID();

            var res = await _db.Reservations
                .Include(r => r.Book) // ensure Book is loaded
                .FirstOrDefaultAsync(r => r.ReservationId == id);

            if (res == null)
                return NotFound(new { Message = "Reservation not found." });

            if (res.MemberId != memberId)
                return Forbid();

            if (res.Status != ReservationStatus.Waiting && res.Status != ReservationStatus.Reserved)
                return BadRequest(new { Message = "Only active reservations can be canceled." });

            bool wasReserved = res.Status == ReservationStatus.Reserved;

            if (wasReserved)
            {
                var nextReservation = await _db.Reservations
                    .Where(r => r.ISBN == res.ISBN && r.Status == ReservationStatus.Waiting)
                    .OrderBy(r => r.Date)
                    .FirstOrDefaultAsync();

                if (nextReservation != null)
                {
                    var settings = await _db.Settings.FirstAsync();
                    nextReservation.ExpiryDate = DateTime.Now.AddDays(settings.ReservationExpiryDays);
                    nextReservation.Status = ReservationStatus.Reserved;
                }
                else if (res.Book != null)
                {
                    res.Book.AvailableCopies++;
                }
            }

            res.Status = ReservationStatus.Canceled;
            await _db.SaveChangesAsync();

            return Ok(new { Message = "Reservation canceled successfully" });
        }

    }
}
