using Final_Project_LoanAPI.Data;
using Final_Project_LoanAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace Final_Project_LoanAPI.Controllers
{
    public class LoanController : ControllerBase
    {
        private readonly ILoanService _loanService;
        public LoanController(ILoanService loanService)
        {
            _loanService = loanService;
        }

        public async Task<IActionResult> CreateLoan()
        {
            return Ok();
        }

        public async Task<IActionResult> GetLoans()
        {
            return Ok();
        }

        public async Task<IActionResult> GetLoanById()
        {
            return Ok();
        }
    }

}
