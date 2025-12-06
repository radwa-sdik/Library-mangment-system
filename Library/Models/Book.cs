using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Models
{
    [Index(nameof(ISBN), IsUnique = true)]
    [Index(nameof(Title))]
    [Index(nameof(Author))]
    public class Book
    {
        [MaxLength(30)]
        [Key]
        public string ISBN { get; set; }
        [MaxLength(200)]
        public string Title { get; set; }
        public string? Description { get; set; }
        [MaxLength(50)]
        public string? Language { get; set; }
        [MaxLength(150)]
        public string? Author { get; set; }
        [Range(0, int.MaxValue)]
        public int TotalCopies { get; set; }
        [Range(0, int.MaxValue)]
        public int AvailableCopies { get; set; }
        public int? YearOfPublication { get; set; } = null;
        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }
        [MaxLength(500)]
        public string? ImageUrl { get; set; }

        public int? PublisherId { get; set; } = null;
        public Publisher Publisher { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        [NotMapped]
        public bool isAvaliable => AvailableCopies > 0;

        public ICollection<BorrowingBook> Borrowings { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
    }
}
