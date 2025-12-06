namespace Library.DTOs
{
    /// <summary>
    /// Data Transfer Object for member fine summary information.
    /// </summary>
    public class MemberFineSummaryDTO
    {
        /// <summary>
        /// Gets or sets the unique identifier for the member.
        /// </summary>
        public int MemberID { get; set; }

        /// <summary>
        /// Gets or sets the name of the member.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the email address of the member.
        /// </summary>
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the total unpaid fine amount in decimal currency.
        /// </summary>
        public decimal TotalUnpaid { get; set; }

        /// <summary>
        /// Gets or sets the count of outstanding fines.
        /// </summary>
        public int FineCount { get; set; }

        /// <summary>
        /// Gets or sets the date of the oldest fine.
        /// </summary>
        public DateTime OldestFineDate { get; set; }
    }
}