namespace Library.Models
{
    public class Settings
    {
        public int SettingsId { get; set; }
        public decimal DailyFineRate { get; set; } = 0.50m;
        public int MaxBorrowDays { get; set; } = 14;
        public int ReservationExpiryDays { get; set; } = 3;
    }
}
