using System.ComponentModel.DataAnnotations;
using static Library.Models.Enums;

namespace Library.DTOs
{
    /// <summary>
    /// Data Transfer Object for member reservation details.
    /// </summary>
    public class MemberReservationDTO
    {
        /// <summary>
        /// Gets or sets the unique identifier for the reservation.
        /// </summary>
        public int ReservationID { get; set; }

        /// <summary>
        /// Gets or sets the ISBN of the reserved book.
        /// </summary>
        [Required(ErrorMessage = "ISBN is required.")]
        [MaxLength(30, ErrorMessage = "ISBN cannot exceed 30 characters.")]
        public string ISBN { get; set; }

        /// <summary>
        /// Gets or sets the title of the reserved book.
        /// </summary>
        [Required(ErrorMessage = "Book title is required.")]
        public string BookTitle { get; set; }

        /// <summary>
        /// Gets or sets the current status of the reservation.
        /// </summary>
        [Required(ErrorMessage = "Status is required.")]
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the expiry date of the reservation, if applicable.
        /// </summary>
        public DateTime? ExpiryDate { get; set; }

        /// <summary>
        /// Gets or sets the date the reservation was created.
        /// </summary>
        public DateTime Date { get; set; }
    }
}
