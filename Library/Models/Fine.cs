using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Models
{
    public class Fine
    {
        public int FineId { get; set; }
        public int MemberId { get; set; }
        public ApplicationUser Member { get; set; }

        public int BorrowingId { get; set; }  
        public BorrowingBook Borrowing { get; set; }

        /// <summary>
        /// The total fine amount. Updated daily by the background service until paid.
        /// </summary>
        [Range(0, double.MaxValue)]
        public decimal Amount { get; set; }

        /// <summary>
        /// The due date of the associated borrowing (when the fine period started).
        /// </summary>
        [NotMapped]
        public DateTime BorrowingDueDate { get; set; }

        /// <summary>
        /// The date this fine record was created in the system.
        /// </summary>
        public DateTime FineDate { get; set; } = DateTime.Now;

        public bool IsPaid { get; set; } = false;
        public DateTime? PaidDate { get; set; }

        /// <summary>
        /// Calculated property: Number of days the book is/was overdue.
        /// </summary>
        public int DaysOverdue => IsPaid 
            ? (PaidDate.HasValue ? (PaidDate.Value.Date - BorrowingDueDate.Date).Days : 0) 
            : (DateTime.Now.Date - BorrowingDueDate.Date).Days;
    }
}
