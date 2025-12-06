namespace Library.Models
{
    public static class Enums
    {
        public enum Role { Admin, Member }
        public enum BorrowingStatus { Borrowed, Returned, OverDue }
        public enum ReservationStatus { Waiting, Completed, Canceled, Expired, Reserved }

    }
}
