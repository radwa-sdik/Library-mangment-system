using Library.Data;
using Library.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library.Controllers
{
    /// <summary>
    /// Controller responsible for system settings management. Admin only. Provides endpoints for retrieving and updating library configuration.
    /// </summary>
    [ApiController]
    [Route("api/admin/[controller]")]
    [Authorize(Roles = "Admin")]
    public class SettingsController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        /// <summary>
        /// Initializes a new instance of the SettingsController class.
        /// </summary>
        /// <param name="db">Application database context</param>
        public SettingsController(ApplicationDbContext db) => _db = db;

        /// <summary>
        /// Retrieves current system settings.
        /// </summary>
        /// <returns>Current settings including fine rate, reservation expiry days, and max borrow days</returns>
        /// <response code="200">Returns current settings</response>
        /// <response code="401">User is not authenticated</response>
        /// <response code="403">User is not an admin</response>
        /// <response code="404">Settings not found</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetSettings()
        {
            var settings = await _db.Settings.FirstOrDefaultAsync();
            if (settings == null)
                return NotFound(new { Message = "Settings not found." });

            var dto = new SettingsDTO
            {
                DailyFineRate = settings.DailyFineRate,
                ReservationExpiryDays = settings.ReservationExpiryDays,
                MaxBorrowDays = settings.MaxBorrowDays
            };

            return Ok(dto);
        }

        /// <summary>
        /// Updates system settings.
        /// </summary>
        /// <param name="dto">Updated settings containing fine rate, reservation expiry days, and max borrow days</param>
        /// <returns>OK response if successful</returns>
        /// <response code="200">Settings updated successfully</response>
        /// <response code="400">Invalid model data or validation failed</response>
        /// <response code="401">User is not authenticated</response>
        /// <response code="403">User is not an admin</response>
        /// <response code="404">Settings not found</response>
        [HttpPut("update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateSettings([FromBody] SettingsDTO dto)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                return BadRequest(new { Errors = errors });
            }

            var settings = await _db.Settings.FirstOrDefaultAsync();
            if (settings == null)
                return NotFound(new { Message = "Settings not found." });

            settings.DailyFineRate = dto.DailyFineRate ?? settings.DailyFineRate;
            settings.ReservationExpiryDays = dto.ReservationExpiryDays ?? settings.ReservationExpiryDays;
            settings.MaxBorrowDays = dto.MaxBorrowDays ?? settings.MaxBorrowDays;

            await _db.SaveChangesAsync();
            return Ok(new { Message = "Settings updated successfully", Settings = settings });
        }
    }
}
