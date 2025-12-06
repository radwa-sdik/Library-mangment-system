using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class Publisher
    {
        public int PublisherId { get; set; }
        [MaxLength(150)]
        public string Name { get; set; }
        public ICollection<Book> Books { get; set; }
    }

}
