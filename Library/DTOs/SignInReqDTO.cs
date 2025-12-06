using Library.Models;
using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace Library.DTOs
{
    public class SignInReqDTO
    {
        [Required(ErrorMessage = "Email is required.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }
    }

}
