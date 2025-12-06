namespace Library.DTOs
{
    public class BorrowingResponseDTO
    {
        public int BorrowingId { get; set; }
        public string ISBN { get; set; }
        public string BookTitle { get; set; }
        public string? BookAuthor { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public string Status { get; set; }
        public int DaysBorrowed { get; set; }
        public bool IsOverdue { get; set; }
    }
}