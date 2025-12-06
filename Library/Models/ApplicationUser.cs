using AutoMapper.Execution;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    [Index(nameof(Email),IsUnique = true)]
    public class ApplicationUser : IdentityUser<int>
    {
        [Required(ErrorMessage = "User name is required")]
        public override string? UserName { get; set; }
        public string? Address { get; set; }
        public DateTime MembershipDate { get; set; } = DateTime.Now;
        [Required(ErrorMessage = "Email is required")]
        public override string Email { get; set; }
        public bool isActive { get; set; } = true;
        public DateTime LastLogin { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // navigation
        public ICollection<BorrowingBook> BorrowingBooks { get; set; } = new List<BorrowingBook>();
        public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
        public ICollection<Fine> Fines { get; set; } = new List<Fine>();

    }

}
