using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        public ICollection<Book> Books { get; set; }
    }

}
