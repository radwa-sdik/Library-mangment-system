using Library.Models;
using static Library.Models.Enums;

namespace Library.DTOs
{
    public class BorrowingDetailsDTO
    {
        public int LoanID { get; set; }
        public string ISBN { get; set; }
        public string BookTitle { get; set; }
        public DateTime Borrow_Date { get; set; }
        public DateTime Due_Date { get; set; }
        public DateTime? Return_Date { get; set; }
        public BorrowingStatus Status { get; set; }
    }


}
