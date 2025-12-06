using Library.Data;
using Library.DTOs;
using Library.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library.Controllers
{
    /// <summary>
    /// Controller responsible for category management operations. Provides endpoints for retrieving, creating, updating, and deleting book categories.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        /// <summary>
        /// Initializes a new instance of the CategoryController class.
        /// </summary>
        /// <param name="db">Application database context</param>
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        /// <summary>
        /// Retrieves all book categories from the system.
        /// </summary>
        /// <returns>List of all categories</returns>
        /// <response code="200">Returns list of all categories</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _db.Categories
                .Select(c => new CategoryDTO
                {
                    CategoryID = c.CategoryId,
                    Name = c.Name
                }).ToListAsync();

            return Ok(categories);
        }

        /// <summary>
        /// Creates a new book category. Admin only.
        /// </summary>
        /// <param name="dto">Category creation data including category name</param>
        /// <returns>OK response if successful</returns>
        /// <response code="200">Category created successfully</response>
        /// <response code="400">Invalid model data or validation failed</response>
        /// <response code="401">User is not authenticated</response>
        /// <response code="403">User is not an admin</response>
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Create([FromBody] CreateCategoryDTO dto)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                return BadRequest(new { Errors = errors });
            }

            var category = new Category
            {
                Name = dto.Name
            };

            await _db.Categories.AddAsync(category);
            await _db.SaveChangesAsync();

            return Ok(new { Message = "Category created successfully", CategoryID = category.CategoryId });
        }

        /// <summary>
        /// Updates an existing category. Admin only.
        /// </summary>
        /// <param name="id">The ID of the category to update</param>
        /// <param name="dto">Updated category data</param>
        /// <returns>OK response if successful, NotFound if category doesn't exist</returns>
        /// <response code="200">Category updated successfully</response>
        /// <response code="400">Invalid model data or validation failed</response>
        /// <response code="401">User is not authenticated</response>
        /// <response code="403">User is not an admin</response>
        /// <response code="404">Category not found</response>
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateCategoryDTO dto)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                return BadRequest(new { Errors = errors });
            }

            var category = await _db.Categories.FindAsync(id);
            if (category == null)
                return NotFound(new { Message = "Category not found." });

            category.Name = dto.Name;
            await _db.SaveChangesAsync();

            return Ok(new { Message = "Category updated successfully" });
        }

        /// <summary>
        /// Deletes a category from the system. Admin only.
        /// </summary>
        /// <param name="id">The ID of the category to delete</param>
        /// <returns>OK response if successful, NotFound if category doesn't exist</returns>
        /// <response code="200">Category deleted successfully</response>
        /// <response code="401">User is not authenticated</response>
        /// <response code="403">User is not an admin</response>
        /// <response code="404">Category not found</response>
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var category = await _db.Categories.FindAsync(id);
            if (category == null)
                return NotFound(new { Message = "Category not found." });

            _db.Categories.Remove(category);
            await _db.SaveChangesAsync();

            return Ok(new { Message = "Category deleted successfully" });
        }
    }
}
