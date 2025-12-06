using Microsoft.EntityFrameworkCore;
using static Library.Models.Enums;

namespace Library.Models
{
    [Index(nameof(ExpiryDate),nameof(Status))]
    public class Reservation
    {
        public int ReservationId { get; set; }
        public string ISBN { get; set; }
        public Book Book { get; set; }

        public int MemberId { get; set; }
        public ApplicationUser Member { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;
        public DateTime? ExpiryDate { get; set;}
        public ReservationStatus Status { get; set; } = ReservationStatus.Waiting;
    }

}
