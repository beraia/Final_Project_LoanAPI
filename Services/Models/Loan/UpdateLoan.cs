using Final_Project_LoanAPI.Services.Models.Shared;

namespace Final_Project_LoanAPI.Services.Models.Loan
{
    public class UpdateLoanRequest
    {
        public int Id { get; set; }
        public LoanType LoanType { get; set; }
        public decimal Ammount { get; set; }
        public string Currency { get; set; }
        public int LoanPeriod { get; set; }
    }
    public class UpdateLoanResponse : Response
    {

    }
}
