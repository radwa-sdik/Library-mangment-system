using Library.Data;
using Library.DTOs;
using Library.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using static Library.Models.Enums;

namespace Library.Controllers
{
    /// <summary>
    /// Controller responsible for administrative operations including dashboard statistics, reporting, and member management.
    /// Admin role required for all endpoints.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]
    public class AdminController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        /// <summary>
        /// Initializes a new instance of the AdminController class.
        /// </summary>
        /// <param name="db">Application database context</param>
        public AdminController(ApplicationDbContext db) => _db = db;

        // ============= DASHBOARD STATISTICS =============

        /// <summary>
        /// Retrieves comprehensive dashboard statistics including books, members, borrowings, and fines.
        /// </summary>
        /// <returns>Dashboard statistics object</returns>
        /// <response code="200">Returns dashboard statistics</response>
        /// <response code="401">User is not authenticated</response>
        /// <response code="403">User is not an admin</response>
        [HttpGet("dashboard")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> GetDashboardStats()
        {
            var stats = new
            {
                TotalBooks = await _db.Books.CountAsync(),
                TotalMembers = await _db.UserRoles.CountAsync(u => u.RoleId == 2),
                ActiveBorrowings = await _db.BorrowingBooks.CountAsync(b => b.ReturnDate == null),
                OverdueBorrowings = await _db.BorrowingBooks.CountAsync(b => b.Status == BorrowingStatus.OverDue && b.ReturnDate == null),
                TotalFinesCollected = await _db.Fines.Where(f => f.IsPaid).SumAsync(f => (decimal?)f.Amount) ?? 0m,
                PendingFines = await _db.Fines.Where(f => !f.IsPaid).SumAsync(f => (decimal?)f.Amount) ?? 0m,
                ActiveReservations = await _db.Reservations.CountAsync(r => r.Status == ReservationStatus.Waiting || r.Status == ReservationStatus.Reserved),
                AvailableBooks = await _db.Books.SumAsync(b => b.AvailableCopies)
            };

            return Ok(stats);
        }

        // ============= BOOKS STATISTICS =============

        /// <summary>
        /// Retrieves the most borrowed books.
        /// </summary>
        /// <param name="limit">Maximum number of books to return (default: 10)</param>
        /// <returns>List of most borrowed books with borrow counts</returns>
        /// <response code="200">Returns most borrowed books</response>
        /// <response code="401">User is not authenticated</response>
        /// <response code="403">User is not an admin</response>
        [HttpGet("most-borrowed")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> MostBorrowedBooks([FromQuery] int limit = 10)
        {
            var result = await _db.BorrowingBooks
                .GroupBy(b => new { b.ISBN, b.Book.Title, b.Book.Author })
                .Select(g => new
                {
                    ISBN = g.Key.ISBN,
                    Title = g.Key.Title,
                    Author = g.Key.Author,
                    BorrowCount = g.Count(),
                    CurrentlyBorrowed = g.Count(b => b.ReturnDate == null)
                })
                .OrderByDescending(x => x.BorrowCount)
                .Take(limit)
                .ToListAsync();

            return Ok(result);
        }

        /// <summary>
        /// Retrieves the least borrowed books.
        /// </summary>
        /// <param name="limit">Maximum number of books to return (default: 10)</param>
        /// <returns>List of least borrowed books with inventory status</returns>
        /// <response code="200">Returns least borrowed books</response>
        /// <response code="401">User is not authenticated</response>
        /// <response code="403">User is not an admin</response>
        [HttpGet("least-borrowed")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> LeastBorrowedBooks([FromQuery] int limit = 10)
        {
            var allBooks = await _db.Books
                .Select(b => new
                {
                    b.ISBN,
                    b.Title,
                    b.Author,
                    b.TotalCopies,
                    b.AvailableCopies,
                    BorrowCount = b.Borrowings.Count()
                })
                .OrderBy(x => x.BorrowCount)
                .Take(limit)
                .ToListAsync();

            return Ok(allBooks);
        }

        /// <summary>
        /// Retrieves books that have never been borrowed.
        /// </summary>
        /// <returns>List of books with zero borrowing activity</returns>
        /// <response code="200">Returns never borrowed books</response>
        /// <response code="401">User is not authenticated</response>
        /// <response code="403">User is not an admin</response>
        [HttpGet("books-never-borrowed")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> BooksNeverBorrowed()
        {
            var neverBorrowed = await _db.Books
                .Where(b => !b.Borrowings.Any())
                .Select(b => new
                {
                    b.ISBN,
                    b.Title,
                    b.Author,
                    b.YearOfPublication,
                    CategoryName = b.Category != null ? b.Category.Name : "N/A",
                    b.TotalCopies,
                    b.AvailableCopies
                })
                .ToListAsync();

            return Ok(neverBorrowed);
        }

        /// <summary>
        /// Retrieves books with low stock levels.
        /// </summary>
        /// <param name="threshold">Stock level threshold (default: 3)</param>
        /// <returns>List of books below threshold availability</returns>
        /// <response code="200">Returns low stock books</response>
        /// <response code="401">User is not authenticated</response>
        /// <response code="403">User is not an admin</response>
        [HttpGet("low-stock-books")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> LowStockBooks([FromQuery] int threshold = 3)
        {
            var lowStock = await _db.Books
                .Where(b => b.AvailableCopies <= threshold && b.AvailableCopies > 0)
                .Select(b => new
                {
                    b.ISBN,
                    b.Title,
                    b.Author,
                    b.TotalCopies,
                    b.AvailableCopies,
                    CurrentlyBorrowed = b.TotalCopies - b.AvailableCopies
                })
                .OrderBy(b => b.AvailableCopies)
                .ToListAsync();

            return Ok(lowStock);
        }

        /// <summary>
        /// Retrieves books that are out of stock.
        /// </summary>
        /// <returns>List of books with no available copies and their reservation counts</returns>
        /// <response code="200">Returns out of stock books</response>
        /// <response code="401">User is not authenticated</response>
        /// <response code="403">User is not an admin</response>
        [HttpGet("out-of-stock-books")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> OutOfStockBooks()
        {
            var outOfStock = await _db.Books
                .Where(b => b.AvailableCopies == 0)
                .Select(b => new
                {
                    b.ISBN,
                    b.Title,
                    b.Author,
                    b.TotalCopies,
                    ReservationCount = b.Reservations.Count(r => r.Status == ReservationStatus.Waiting)
                })
                .ToListAsync();

            return Ok(outOfStock);
        }

        // ============= MEMBER STATISTICS =============

        /// <summary>
        /// Retrieves the most active members by borrowing activity.
        /// </summary>
        /// <param name="limit">Maximum number of members to return (default: 10)</param>
        /// <returns>List of active members with borrowing and fine statistics</returns>
        /// <response code="200">Returns most active members</response>
        /// <response code="401">User is not authenticated</response>
        /// <response code="403">User is not an admin</response>
        [HttpGet("most-active-members")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> MostActiveMembers([FromQuery] int limit = 10)
        {
            var activeMembers = await _db.Users
                .Join(_db.UserRoles,
                      u => u.Id,
                      ur => ur.UserId,
                      (u, ur) => new { User = u, UserRole = ur })
                .Where(u => u.UserRole.RoleId == 2)
                .Select(u => new
                {
                    MemberId = u.User.Id,
                    u.User.UserName,
                    u.User.Email,
                    TotalBorrowings = u.User.BorrowingBooks.Count(),
                    CurrentBorrowings = u.User.BorrowingBooks.Count(b => b.ReturnDate == null),
                    TotalFines = u.User.Fines.Sum(f => (decimal?)f.Amount) ?? 0m,
                    UnpaidFines = u.User.Fines.Where(f => !f.IsPaid).Sum(f => (decimal?)f.Amount) ?? 0m,
                    u.User.isActive
                })
                .OrderByDescending(x => x.TotalBorrowings)
                .Take(limit)
                .ToListAsync();

            return Ok(activeMembers);
        }

        /// <summary>
        /// Retrieves inactive members based on login activity.
        /// </summary>
        /// <param name="daysInactive">Number of days to consider a member inactive (default: 90)</param>
        /// <returns>List of inactive members with last login information</returns>
        /// <response code="200">Returns inactive members</response>
        /// <response code="401">User is not authenticated</response>
        /// <response code="403">User is not an admin</response>
        [HttpGet("inactive-members")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> InactiveMembers([FromQuery] int daysInactive = 90)
        {
            var thresholdDate = DateTime.Now.AddDays(-daysInactive);
            
            var inactiveMembers = await _db.Users
                .Join(_db.UserRoles,
                      u => u.Id,
                      ur => ur.UserId,
                      (u, ur) => new { User = u, UserRole = ur })
                .Where(u => u.UserRole.RoleId == 2 && 
                           u.User.LastLogin < thresholdDate)
                .Select(u => new
                {
                    MemberId = u.User.Id,
                    u.User.UserName,
                    u.User.Email,
                    u.User.LastLogin,
                    DaysInactive = (DateTime.Now - u.User.LastLogin).Days,
                    u.User.isActive
                })
                .OrderBy(x => x.LastLogin)
                .ToListAsync();

            return Ok(inactiveMembers);
        }

        // ============= FINES MANAGEMENT =============

        /// <summary>
        /// Retrieves members with unpaid fines.
        /// </summary>
        /// <returns>List of members with unpaid fine summaries</returns>
        /// <response code="200">Returns members with unpaid fines</response>
        /// <response code="401">User is not authenticated</response>
        /// <response code="403">User is not an admin</response>
        [HttpGet("unpaid-fines")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> MembersWithUnpaidFines()
        {
            var settings = await _db.Settings.FirstAsync();
            
            var data = await _db.Fines
                .Where(f => !f.IsPaid)
                .GroupBy(f => f.MemberId)
                .Select(g => new MemberFineSummaryDTO
                {
                    MemberID = g.Key,
                    Name = g.First().Member.UserName ?? "Unknown",
                    Email = g.First().Member.Email ?? "",
                    TotalUnpaid = g.Sum(x => x.Amount),
                    FineCount = g.Count(),
                    OldestFineDate = g.Min(x => x.FineDate)
                })
                .OrderByDescending(x => x.TotalUnpaid)
                .ToListAsync();

            return Ok(data);
        }

        /// <summary>
        /// Retrieves all fines with optional filtering by payment status.
        /// </summary>
        /// <param name="isPaid">Optional filter for fine payment status</param>
        /// <returns>List of fines with member and borrowing details</returns>
        /// <response code="200">Returns all fines</response>
        /// <response code="401">User is not authenticated</response>
        /// <response code="403">User is not an admin</response>
        [HttpGet("all-fines")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> AllFines([FromQuery] bool? isPaid = null)
        {
            var query = _db.Fines.AsQueryable();

            if (isPaid.HasValue)
            {
                query = query.Where(f => f.IsPaid == isPaid.Value);
            }

            var fines = await query
                .Include(f => f.Member)
                .Include(f => f.Borrowing)
                    .ThenInclude(b => b.Book)
                .Select(f => new
                {
                    FineId = f.FineId,
                    MemberId = f.MemberId,
                    MemberName = f.Member.UserName,
                    MemberEmail = f.Member.Email,
                    BorrowingId = f.BorrowingId,
                    ISBN = f.Borrowing.ISBN,
                    BookTitle = f.Borrowing.Book.Title,
                    Amount = f.Amount,
                    FineDate = f.FineDate,
                    IsPaid = f.IsPaid,
                    PaidDate = f.PaidDate,
                    DaysOverdue = f.DaysOverdue
                })
                .OrderByDescending(f => f.FineDate)
                .ToListAsync();

            return Ok(fines);
        }

        // ============= BORROWINGS MANAGEMENT =============

        /// <summary>
        /// Retrieves overdue borrowings with member and book information.
        /// </summary>
        /// <returns>List of overdue borrowings</returns>
        /// <response code="200">Returns overdue borrowings</response>
        /// <response code="401">User is not authenticated</response>
        /// <response code="403">User is not an admin</response>
        [HttpGet("overdue")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> OverdueBorrowings()
        {
            var overdue = await _db.BorrowingBooks
                .Include(b => b.Member)
                .Where(b => b.Status == BorrowingStatus.OverDue && b.ReturnDate == null)
                .Select(b => new OverdueBorrowingDTO
                {
                    LoanID = b.BorrowingId,
                    MemberId = b.MemberId,
                    MemberName = b.Member.UserName ?? "Unknown",
                    MemberEmail = b.Member.Email ?? "",
                    ISBN = b.ISBN,
                    BookTitle = b.Book.Title,
                    BorrowDate = b.BorrowDate,
                    DueDate = b.DueDate,
                    DaysOverdue = (DateTime.Now.Date - b.DueDate.Date).Days,
                    HasFine = b.Member.Fines.Any(f => f.BorrowingId == b.BorrowingId)
                })
                .OrderBy(b => b.DueDate)
                .ToListAsync();

            return Ok(overdue);
        }

        /// <summary>
        /// Retrieves all borrowings with optional filtering by status.
        /// </summary>
        /// <param name="status">Optional filter for borrowing status</param>
        /// <returns>List of borrowings with member and book details</returns>
        /// <response code="200">Returns all borrowings</response>
        /// <response code="401">User is not authenticated</response>
        /// <response code="403">User is not an admin</response>
        [HttpGet("all-borrowings")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> AllBorrowings([FromQuery] string? status = null)
        {
            var query = _db.BorrowingBooks.AsQueryable();

            if (!status.IsNullOrEmpty())
            {
                if (Enum.TryParse<Enums.BorrowingStatus>(status, out var parsedStatus))
                {
                    query = query.Where(b => b.Status == parsedStatus);
                }              
            }

            var borrowings = await query
                .Include(b => b.Book)
                .Include(b => b.Member)
                .Select(b => new
                {
                    BorrowingId = b.BorrowingId,
                    MemberId = b.MemberId,
                    MemberName = b.Member.UserName,
                    ISBN = b.ISBN,
                    BookTitle = b.Book.Title,
                    BorrowDate = b.BorrowDate,
                    DueDate = b.DueDate,
                    ReturnDate = b.ReturnDate,
                    Status = b.Status.ToString(),
                    DaysBorrowed = b.daysBorrowed
                })
                .OrderByDescending(b => b.BorrowDate)
                .ToListAsync();

            return Ok(borrowings);
        }

        // ============= RESERVATIONS MANAGEMENT =============

        /// <summary>
        /// Retrieves reservations with optional filtering by status.
        /// </summary>
        /// <param name="status">Optional filter for reservation status</param>
        /// <returns>List of reservations with member and book details</returns>
        /// <response code="200">Returns all reservations</response>
        /// <response code="401">User is not authenticated</response>
        /// <response code="403">User is not an admin</response>
        [HttpGet("reservations")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Reservations([FromQuery] string? status = null)
        {
            var query = _db.Reservations.AsQueryable();

            if (!status.IsNullOrEmpty())
            {
                if (Enum.TryParse<Enums.ReservationStatus>(status, out var parsedStatus))
                {
                    query = query.Where(b => b.Status == parsedStatus);
                }
            }

            var reservations = await query
                .Include(r => r.Book)
                .Include(r => r.Member)
                .Select(r => new AllReservationsDTO
                {
                    ReservationID = r.ReservationId,
                    ISBN = r.ISBN,
                    BookTitle = r.Book.Title,
                    MemberID = r.MemberId,
                    MemberName = r.Member.UserName ?? "Unknown",
                    MemberEmail = r.Member.Email ?? "",
                    Date = r.Date,
                    ExpiryDate = r.ExpiryDate,
                    Status = r.Status.ToString()
                })
                .OrderByDescending(r => r.Date)
                .ToListAsync();

            return Ok(reservations);
        }

        /// <summary>
        /// Retrieves expired reservations.
        /// </summary>
        /// <returns>List of expired reservations with corresponding book and member information</returns>
        /// <response code="200">Returns expired reservations</response>
        /// <response code="401">User is not authenticated</response>
        /// <response code="403">User is not an admin</response>
        [HttpGet("expired-reservations")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> ExpiredReservations()
        {
            var expired = await _db.Reservations
                .Where(r => r.Status == ReservationStatus.Reserved && r.ExpiryDate < DateTime.Now)
                .Select(r => new
                {
                    r.ReservationId,
                    r.ISBN,
                    BookTitle = r.Book.Title,
                    r.MemberId,
                    MemberName = r.Member.UserName,
                    r.Date,
                    r.ExpiryDate,
                    DaysExpired = r.ExpiryDate == null ? 0 : (DateTime.Now.Date - r.ExpiryDate.Value.Date).Days
                })
                .ToListAsync();

            return Ok(expired);
        }

        // ============= CATEGORY & PUBLISHER STATISTICS =============

        /// <summary>
        /// Retrieves statistics for book categories.
        /// </summary>
        /// <returns>List of categories with book and borrowing statistics</returns>
        /// <response code="200">Returns category statistics</response>
        /// <response code="401">User is not authenticated</response>
        /// <response code="403">User is not an admin</response>
        [HttpGet("category-statistics")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> CategoryStatistics()
        {
            var stats = await _db.Categories
                .Select(c => new
                {
                    CategoryId = c.CategoryId,
                    CategoryName = c.Name,
                    TotalBooks = c.Books.Count(),
                    TotalCopies = c.Books.Sum(b => b.TotalCopies),
                    AvailableCopies = c.Books.Sum(b => b.AvailableCopies),
                    TotalBorrowings = c.Books.SelectMany(b => b.Borrowings).Count(),
                    CurrentlyBorrowed = c.Books.SelectMany(b => b.Borrowings).Count(br => br.ReturnDate == null)
                })
                .OrderByDescending(x => x.TotalBorrowings)
                .ToListAsync();

            return Ok(stats);
        }

        /// <summary>
        /// Retrieves statistics for book publishers.
        /// </summary>
        /// <returns>List of publishers with book and borrowing statistics</returns>
        /// <response code="200">Returns publisher statistics</response>
        /// <response code="401">User is not authenticated</response>
        /// <response code="403">User is not an admin</response>
        [HttpGet("publisher-statistics")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> PublisherStatistics()
        {
            var stats = await _db.Publishers
                .Select(p => new
                {
                    PublisherId = p.PublisherId,
                    PublisherName = p.Name,
                    TotalBooks = p.Books.Count(),
                    TotalCopies = p.Books.Sum(b => b.TotalCopies),
                    AvailableCopies = p.Books.Sum(b => b.AvailableCopies),
                    TotalBorrowings = p.Books.SelectMany(b => b.Borrowings).Count()
                })
                .OrderByDescending(x => x.TotalBooks)
                .ToListAsync();

            return Ok(stats);
        }

        // ============= REVENUE & FINANCIAL REPORTS =============

        /// <summary>
        /// Generates a revenue report based on fine payments within a date range.
        /// </summary>
        /// <param name="startDate">Optional start date for the report</param>
        /// <param name="endDate">Optional end date for the report</param>
        /// <returns>Revenue report data including total and monthly breakdown</returns>
        /// <response code="200">Returns revenue report</response>
        /// <response code="401">User is not authenticated</response>
        /// <response code="403">User is not an admin</response>
        [HttpGet("revenue-report")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> RevenueReport([FromQuery] DateTime? startDate = null, [FromQuery] DateTime? endDate = null)
        {
            var start = startDate ?? DateTime.Now.AddMonths(-12);
            var end = endDate ?? DateTime.Now;

            var revenue = new
            {
                TotalFinesCollected = await _db.Fines
                    .Where(f => f.IsPaid && f.PaidDate >= start && f.PaidDate <= end)
                    .SumAsync(f => (decimal?)f.Amount) ?? 0m,

                TotalPendingFines = await _db.Fines
                    .Where(f => !f.IsPaid)
                    .SumAsync(f => (decimal?)f.Amount) ?? 0m,

                //Total books borrowed in the period * price per book
                TotalRevenueFromBorrowings = _db.BorrowingBooks
                    .Include(b => b.Book)
                    .Where(b => b.BorrowDate >= start && b.BorrowDate <= end)
                    .Select(b => b.Book.Price)
                    .Sum(),

                MonthlyBreakdown = await _db.Fines
                    .Where(f => f.IsPaid && f.PaidDate >= start && f.PaidDate <= end)
                    .GroupBy(f => new { f.PaidDate!.Value.Year, f.PaidDate.Value.Month })
                    .Select(g => new
                    {
                        Year = g.Key.Year,
                        Month = g.Key.Month,
                        Amount = g.Sum(f => f.Amount),
                        Count = g.Count()
                    })
                    .OrderBy(x => x.Year)
                    .ThenBy(x => x.Month)
                    .ToListAsync()
            };

            return Ok(revenue);
        }

        // ============= MEMBER ACTIONS =============

        /// <summary>
        /// Toggles the active status of a member.
        /// </summary>
        /// <param name="memberId">ID of the member</param>
        /// <returns>Action result with status message</returns>
        /// <response code="200">Returns updated member status</response>
        /// <response code="404">Member not found</response>
        /// <response code="401">User is not authenticated</response>
        /// <response code="403">User is not an admin</response>
        [HttpPut("toggle-member-status/{memberId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> ToggleMemberStatus(int memberId)
        {
            var member = await _db.Users.FindAsync(memberId);
            if (member == null)
                return NotFound("Member not found");

            member.isActive = !member.isActive;
            await _db.SaveChangesAsync();

            return Ok(new { Message = $"Member status updated to {(member.isActive ? "Active" : "Inactive")}", IsActive = member.isActive });
        }
    }
}
