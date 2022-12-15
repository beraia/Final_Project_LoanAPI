namespace Final_Project_LoanAPI.Models
{
    public class Loan
    {
        public int Id { get; set; }
        public LoanType LoanType { get; set; }
        public decimal Ammount { get; set; }
        public string Currency { get; set; }
        public int LoanPeriod { get; set; }
        public Status Status { get; set; } = Status.UnderProcessing;
    }
}
