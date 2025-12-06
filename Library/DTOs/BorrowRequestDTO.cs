using System.ComponentModel.DataAnnotations;

namespace Library.DTOs
{
    /// <summary>
    /// Data Transfer Object for book borrow requests.
    /// </summary>
    public class BorrowRequestDTO
    {
        /// <summary>
        /// Gets or sets the ISBN of the book to borrow.
        /// </summary>
        [Required(ErrorMessage = "ISBN is required.")]
        [MaxLength(30, ErrorMessage = "ISBN cannot exceed 30 characters.")]
        public string ISBN { get; set; }

        /// <summary>
        /// Gets or sets the number of days to borrow the book. Default is 3 days.
        /// </summary>
        [Range(1, 90, ErrorMessage = "Number of days must be between 1 and 90.")]
        public int numberOfDays { get; set; } = 3;
    }
}
