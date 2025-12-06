using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Library.Models.Enums;

namespace Library.Models
{
    public class BorrowingBook
    {
        [Key]
        public int BorrowingId { get; set; }
        public string ISBN { get; set; }
        public Book Book { get; set; }

        public int MemberId { get; set; }
        public ApplicationUser Member { get; set; }
        public int daysBorrowed { get; set; } = 3;

        public DateTime BorrowDate { get; set; } = DateTime.Now;
        public DateTime DueDate { get; set; }
        public DateTime? ReturnDate { get; set; }

        [NotMapped]
        public BorrowingStatus realStatues => ReturnDate == null && DateTime.Now > DueDate ? BorrowingStatus.OverDue :
                                              ReturnDate == null ? BorrowingStatus.Borrowed :
                                              BorrowingStatus.Returned;

        public BorrowingStatus Status { get; set; } = BorrowingStatus.Borrowed;
    }

}
