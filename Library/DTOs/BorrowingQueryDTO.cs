namespace Library.DTOs
{
    public class BorrowingQueryDTO
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string? Status { get; set; } // Borrowed, Returned, OverDue
        public string? ISBN { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public bool? IsOverdue { get; set; }
    }
}