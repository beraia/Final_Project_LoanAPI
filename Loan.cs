namespace Final_Project_LoanAPI
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

enum LoanType
{
    FastLoan,
    AutoLoan,
    Installment
}

enum Status
{
    UnderProcessing,
    Approved,
    Rejected
}