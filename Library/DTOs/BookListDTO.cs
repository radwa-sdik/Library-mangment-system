namespace Library.DTOs
{
    public class BookListDTO
    {
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public string? Language { get; set; }
        public string? Author { get; set; }
        public string Category { get; set; }
        public string? Publisher { get; set; }
        public int AvailableCopies { get; set; }
        public int TotalCopies { get; set; }
        public string? CoverImageUrl { get; set; }
    }

}
