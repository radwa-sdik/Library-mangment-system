using System.ComponentModel.DataAnnotations;
using static Library.Models.Enums;

namespace Library.DTOs
{
    public class SignUpReqDTO
    {
        [MaxLength(100)]
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }
        [EmailAddress]
        [Required(ErrorMessage = "Email is required.")]
        [MaxLength(120)]
        public string Email { get; set; }
        [Phone]
        [MaxLength(20)]
        public string? PhoneNumber { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        [MaxLength(120)]
        public string Password { get; set; }
        public string? Address { get; set; }
        public string Role { get; set; } = "Member";
    }
}
