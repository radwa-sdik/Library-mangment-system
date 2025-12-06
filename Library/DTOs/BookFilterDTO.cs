namespace Library.DTOs
{
    public class BookFilterDTO
    {
        public int? CategoryID { get; set; }
        public int? PublisherID { get; set; }
        public string? Author { get; set; }
        public bool? IsAvailable { get; set; }
        public string? Search { get; set; }  // title or ISBN
    }

}
