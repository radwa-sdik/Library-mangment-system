using Microsoft.AspNetCore.Mvc;
using Library.Data;
using Library.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Library.DTOs;

namespace Library.Controllers
{
    /// <summary>
    /// Controller responsible for publisher management operations. Provides endpoints for retrieving, creating, updating, and deleting book publishers.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class PublisherController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        /// <summary>
        /// Initializes a new instance of the PublisherController class.
        /// </summary>
        /// <param name="db">Application database context</param>
        public PublisherController(ApplicationDbContext db)
        {
            _db = db;
        }

        /// <summary>
        /// Retrieves all publishers from the system.
        /// </summary>
        /// <returns>List of all publishers</returns>
        /// <response code="200">Returns list of all publishers</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var publishers = await _db.Publishers
                .Select(p => new PublisherDTO
                {
                    PublisherID = p.PublisherId,
                    Name = p.Name
                }).ToListAsync();

            return Ok(publishers);
        }

        /// <summary>
        /// Creates a new publisher. Admin only.
        /// </summary>
        /// <param name="dto">Publisher creation data including publisher name</param>
        /// <returns>OK response if successful</returns>
        /// <response code="200">Publisher created successfully</response>
        /// <response code="400">Invalid model data or validation failed</response>
        /// <response code="401">User is not authenticated</response>
        /// <response code="403">User is not an admin</response>
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Create([FromBody] CreatePublisherDTO dto)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                return BadRequest(new { Errors = errors });
            }

            var publisher = new Publisher
            {
                Name = dto.Name
            };

            await _db.Publishers.AddAsync(publisher);
            await _db.SaveChangesAsync();

            return Ok(new { Message = "Publisher created successfully", PublisherID = publisher.PublisherId });
        }

        /// <summary>
        /// Updates an existing publisher. Admin only.
        /// </summary>
        /// <param name="id">The ID of the publisher to update</param>
        /// <param name="dto">Updated publisher data</param>
        /// <returns>OK response if successful, NotFound if publisher doesn't exist</returns>
        /// <response code="200">Publisher updated successfully</response>
        /// <response code="400">Invalid model data or validation failed</response>
        /// <response code="401">User is not authenticated</response>
        /// <response code="403">User is not an admin</response>
        /// <response code="404">Publisher not found</response>
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, [FromBody] UpdatePublisherDTO dto)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                return BadRequest(new { Errors = errors });
            }

            var publisher = await _db.Publishers.FindAsync(id);
            if (publisher == null)
                return NotFound(new { Message = "Publisher not found." });

            publisher.Name = dto.Name;
            await _db.SaveChangesAsync();

            return Ok(new { Message = "Publisher updated successfully" });
        }

        /// <summary>
        /// Deletes a publisher from the system. Admin only.
        /// </summary>
        /// <param name="id">The ID of the publisher to delete</param>
        /// <returns>OK response if successful, NotFound if publisher doesn't exist</returns>
        /// <response code="200">Publisher deleted successfully</response>
        /// <response code="401">User is not authenticated</response>
        /// <response code="403">User is not an admin</response>
        /// <response code="404">Publisher not found</response>
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var publisher = await _db.Publishers.FindAsync(id);
            if (publisher == null)
                return NotFound(new { Message = "Publisher not found." });

            _db.Publishers.Remove(publisher);
            await _db.SaveChangesAsync();

            return Ok(new { Message = "Publisher deleted successfully" });
        }
    }
}
