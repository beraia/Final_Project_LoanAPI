using Final_Project_LoanAPI.Data;
using Final_Project_LoanAPI.Services.Models.Shared;

namespace Final_Project_LoanAPI.Services.Models.Loan
{
    public class GetLoansRequest
    {

    }

    public class GetLoansResponse : Response
    {
        public List<Loan> Loans { get; set; } = new List<Loan>();

        public class Loan
        {
            public int Id { get; set; }
            public LoanType LoanType { get; set; }
            public decimal Ammount { get; set; }
            public string Currency { get; set; }
            public int LoanPeriod { get; set; }
            public Status Status { get; set; }
        }
    }
}
