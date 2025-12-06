namespace Library.DTOs
{
    public class FineDTO
    {
        public int FineID { get; set; }
        public int LoanID { get; set; }
        public string ISBN { get; set;} 
        public decimal Amount { get; set; }
        public DateTime FineDate { get; set; }
        public DateTime? PaidDate { get; set; }
        public bool isPaid { get; set; }
    }

}
