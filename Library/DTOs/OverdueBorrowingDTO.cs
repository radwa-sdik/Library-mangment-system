namespace Library.DTOs
{
    public class OverdueBorrowingDTO
    {
        public int LoanID { get; set; }
        public int MemberId { get; set; }
        public string MemberName { get; set; } = string.Empty;
        public string MemberEmail { get; set; } = string.Empty;
        public string ISBN { get; set; } = string.Empty;
        public string BookTitle { get; set; } = string.Empty;
        public DateTime BorrowDate { get; set; }
        public DateTime DueDate { get; set; }
        public int DaysOverdue { get; set; }
        public bool HasFine { get; set; }
    }
}