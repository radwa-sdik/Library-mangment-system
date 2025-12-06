namespace Library.DTOs
{
    public class SettingsDTO
    {
        public decimal? DailyFineRate { get; set; } = null;
        public int? ReservationExpiryDays { get; set; } = null;
        public int? MaxBorrowDays { get; set; } = null;
    }

}
