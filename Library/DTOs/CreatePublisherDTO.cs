using System.ComponentModel.DataAnnotations;

namespace Library.DTOs
{
    public class CreatePublisherDTO
    {
        [MaxLength(150)]
        [Required(ErrorMessage = "Publisher name is required.")]
        public string Name { get; set; }
    }

}
