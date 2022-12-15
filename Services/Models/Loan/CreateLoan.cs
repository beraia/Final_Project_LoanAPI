using Final_Project_LoanAPI.Services.Models.Shared;
using System.ComponentModel.DataAnnotations;

namespace Final_Project_LoanAPI.Services.Models.Loan
{
    public class CreateLoanRequest
    {
        [Required(ErrorMessage = "Loan type is required")]
        public LoanType LoanType { get; set; }

        [Required(ErrorMessage = "Amount is required")]
        public decimal Ammount { get; set; }

        [Required(ErrorMessage = "Currency is required")]
        public string Currency { get; set; }

        [Required(ErrorMessage = "Loan period is required")]
        public int LoanPeriod { get; set; }
    }

    public class CreateLoanResponse : Response
    {
    }
}
