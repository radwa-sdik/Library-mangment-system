namespace Library.DTOs
{
    public class AllReservationsDTO
    {
        public int ReservationID { get; set; }
        public string ISBN { get; set; } = string.Empty;
        public string BookTitle { get; set; } = string.Empty;
        public int MemberID { get; set; }
        public string MemberName { get; set; } = string.Empty;
        public string MemberEmail { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}