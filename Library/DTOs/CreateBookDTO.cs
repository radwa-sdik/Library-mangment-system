using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Library.DTOs
{
    public class CreateBookDTO
    {
        [MaxLength(30)]
        [Required(ErrorMessage = "ISBN is required.")]
        public string ISBN { get; set; }
        [MaxLength(200)]
        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; }
        public string? Description { get; set; }
        public int? YearOfPublication { get; set; } = null;
        [MaxLength(50)]
        public string? Language { get; set; }
        [MaxLength(150)]
        public string? Author { get; set; }
        [Range(0, int.MaxValue)]
        public int TotalCopies { get; set; }
        [Range(0, int.MaxValue)]
        public decimal Price { get; set; } = 0;
        [Required(ErrorMessage = "CategoryID is required.")]
        public int CategoryID { get; set; }
        public int? PublisherID { get; set; } = null;
        public IFormFile? Image { get; set; }
    }

}
