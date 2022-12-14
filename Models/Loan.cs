namespace Final_Project_LoanAPI.Models
{
    public class Loan
    {
        LoanType LoanType { get; set; }
        public decimal Ammount { get; set; }
        public string Currency { get; set; }
        public int LoanPeriod { get; set; }
        Status Status { get; set; } = Status.UnderProcessing;
    }
}
