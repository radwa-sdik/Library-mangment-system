using AutoMapper;
using Library.Data;
using Library.DTOs;
using Library.Models;
using Library.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library.Controllers
{
    /// <summary>
    /// Controller responsible for book management operations including filtering, creation, updates, and deletion.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        private readonly IImageUploadService _imageUploadService;

        /// <summary>
        /// Initializes a new instance of the BooksController class.
        /// </summary>
        /// <param name="db">Application database context</param>
        /// <param name="mapper">AutoMapper instance for object mapping</param>
        /// <param name="imageUploadService">Image upload service for handling book cover images</param>
        public BooksController(ApplicationDbContext db, IMapper mapper, IImageUploadService imageUploadService)
        {
            _db = db;
            _mapper = mapper;
            _imageUploadService = imageUploadService;
        }

        /// <summary>
        /// Retrieves filtered books based on multiple criteria.
        /// </summary>
        /// <param name="filter">Book filter criteria including category, publisher, author, and search terms</param>
        /// <returns>List of books matching the filter criteria</returns>
        /// <response code="200">Returns list of filtered books</response>
        [HttpGet("filter")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> FilterBooks([FromQuery] BookFilterDTO filter)
        {
            var query = _db.Books
                .Include(c => c.Category)
                .Include(p => p.Publisher)
                .AsQueryable();

            if (filter.CategoryID != null)
                query = query.Where(b => b.CategoryId == filter.CategoryID);

            if (filter.PublisherID != null)
                query = query.Where(b => b.PublisherId == filter.PublisherID);

            if (!string.IsNullOrEmpty(filter.Author))
                query = query.Where(b => b.Author.Contains(filter.Author));

            if (filter.IsAvailable == true)
                query = query.Where(b => b.AvailableCopies > 0);

            if (!string.IsNullOrEmpty(filter.Search))
                query = query.Where(b => b.Title.Contains(filter.Search)
                                      || b.ISBN.Contains(filter.Search));

            var result = await query
                .Select(b => new BookListDTO
                {
                    ISBN = b.ISBN,
                    Title = b.Title,
                    Author = b.Author,
                    Category = b.Category.Name,
                    Publisher = b.Publisher.Name,
                    AvailableCopies = b.AvailableCopies,
                    TotalCopies = b.TotalCopies,
                    Description = b.Description,
                    Language = b.Language,
                    CoverImageUrl = b.ImageUrl

                }).ToListAsync();

            return Ok(result);
        }

        [HttpGet("{isbn}")]
        public async Task<IActionResult> GetBookByISBN(string isbn)
        {
            if (string.IsNullOrEmpty(isbn))
                return BadRequest("ISBN is required.");
            var book = await _db.Books
                .Include(c => c.Category)
                .Include(p => p.Publisher)
                .Where(b => b.ISBN == isbn)
                .Select(b => new BookListDTO
                {
                    ISBN = b.ISBN,
                    Title = b.Title,
                    Author = b.Author,
                    Category = b.Category.Name,
                    Publisher = b.Publisher.Name,
                    AvailableCopies = b.AvailableCopies,
                    TotalCopies = b.TotalCopies,
                    Description = b.Description,
                    Language = b.Language,
                    CoverImageUrl = b.ImageUrl
                }).FirstOrDefaultAsync();
            if (book == null)
                return NotFound(new { Message = "Book not found." });
            return Ok(book);
        }

        /// <summary>
        /// Creates a new book in the system. Admin only.
        /// </summary>
        /// <param name="dto">Book creation data including ISBN, title, author, and inventory details</param>
        /// <returns>Created response with the new book if successful</returns>
        /// <response code="201">Book created successfully</response>
        /// <response code="400">Invalid book data or model validation failed</response>
        /// <response code="401">User is not authenticated</response>
        /// <response code="403">User is not an admin</response>
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> CreateBook([FromForm] CreateBookDTO dto)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                return BadRequest(new { Errors = errors });
            }

            var book = _mapper.Map<Book>(dto); 
            
            if (book == null)
                return BadRequest("Invalid book data.");

            // Handle image upload
            if (dto.Image != null)
            {
                try
                {
                    book.ImageUrl = await _imageUploadService.UploadImageAsync(dto.Image, "books");
                }
                catch (ArgumentException ex)
                {
                    return BadRequest(new { Message = ex.Message });
                }
            }

            _db.Books.Add(book);
            await _db.SaveChangesAsync();

            return CreatedAtAction(nameof(FilterBooks), new { isbn = book.ISBN }, book);
        }

        /// <summary>
        /// Updates an existing book. Admin only.
        /// </summary>
        /// <param name="isbn">The ISBN of the book to update</param>
        /// <param name="dto">Updated book data</param>
        /// <returns>OK response if successful, NotFound if book doesn't exist</returns>
        /// <response code="200">Book updated successfully</response>
        /// <response code="400">Invalid model data or validation failed</response>
        /// <response code="401">User is not authenticated</response>
        /// <response code="403">User is not an admin</response>
        /// <response code="404">Book not found</response>
        [Authorize(Roles = "Admin")]
        [HttpPut("{isbn}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateBook(string isbn, [FromForm] UpdateBookDTO dto)
        {
            if (string.IsNullOrEmpty(isbn))
                return BadRequest("ISBN is required.");

            var book = await _db.Books.FindAsync(isbn);
            if (book == null)
                return NotFound(new { Message = "Book not found." });

            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                return BadRequest(new { Errors = errors });
            }

            var nonAvailableBooks = book.TotalCopies - book.AvailableCopies;

            if (dto.TotalCopies < nonAvailableBooks)
                return BadRequest($"Total copies cannot be less than {nonAvailableBooks} because some are issued.");

            // update non-image fields manually
            book.Title = dto.Title;
            book.Author = dto.Author;
            book.Description = dto.Description;
            book.CategoryId = dto.CategoryID;
            book.PublisherId = dto.PublisherID;
            book.Language = dto.Language;

            // compute new availability
            var diff = dto.TotalCopies - book.TotalCopies;
            book.TotalCopies = dto.TotalCopies;
            book.AvailableCopies += diff;

            // validate before saving
            if (book.AvailableCopies < 0 || book.AvailableCopies > book.TotalCopies)
                return BadRequest("Invalid copy numbers.");

            // handle image
            if (dto.Image != null)
            {
                if (!string.IsNullOrEmpty(book.ImageUrl))
                    await _imageUploadService.DeleteImageAsync(book.ImageUrl);

                book.ImageUrl = await _imageUploadService.UploadImageAsync(dto.Image, "books");
            }

            await _db.SaveChangesAsync();
            return Ok("Book Updated Successfully");
        }

        /// <summary>
        /// Deletes a book from the system. Admin only.
        /// </summary>
        /// <param name="isbn">The ISBN of the book to delete</param>
        /// <returns>OK response if successful, NotFound if book doesn't exist</returns>
        /// <response code="200">Book deleted successfully</response>
        /// <response code="401">User is not authenticated</response>
        /// <response code="403">User is not an admin</response>
        /// <response code="404">Book not found</response>
        [Authorize(Roles = "Admin")]
        [HttpDelete("{isbn}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteBook(string isbn)
        {
            if (string.IsNullOrEmpty(isbn))
                return BadRequest("ISBN is required.");

            var book = await _db.Books.FindAsync(isbn);
            if (book == null)
                return NotFound(new { Message = "Book not found." });

            // Delete associated image if exists
            if (!string.IsNullOrEmpty(book.ImageUrl))
            {
                await _imageUploadService.DeleteImageAsync(book.ImageUrl);
            }

            _db.Books.Remove(book);
            await _db.SaveChangesAsync();

            return Ok(new { Message = "Book deleted successfully" });
        }
    }
}
