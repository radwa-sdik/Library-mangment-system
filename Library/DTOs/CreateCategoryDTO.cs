using System.ComponentModel.DataAnnotations;

namespace Library.DTOs
{
    public class CreateCategoryDTO
    {
        [MaxLength(100)]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
    }

}
