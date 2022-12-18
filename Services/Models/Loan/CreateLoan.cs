using Final_Project_LoanAPI.Services.Models.Shared;
using System.ComponentModel.DataAnnotations;

namespace Final_Project_LoanAPI.Services.Models.Loan
{
    public class CreateLoanRequest
    {
        public LoanType LoanType { get; set; }

        public decimal Ammount { get; set; }

        public string? Currency { get; set; }

        public int LoanPeriod { get; set; }
    }

    public class CreateLoanResponse : Response
    {
    }
}
