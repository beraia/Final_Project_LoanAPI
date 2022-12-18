using Final_Project_LoanAPI.Data;
using Final_Project_LoanAPI.Services;
using Final_Project_LoanAPI.Services.Models.Loan;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Final_Project_LoanAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class LoanController : ControllerBase
    {
        private readonly ILoanService _loanService;
        public LoanController(ILoanService loanService)
        {
            _loanService = loanService;
        }

        [Authorize()]
        [HttpPost]
        [Route("CreateLoan")]
        public async Task<IActionResult> CreateLoan([FromQuery] CreateLoanRequest request)
        {
            var response = await _loanService.CreateLoan(request);
            if(response.Succsess)
            {
                return Ok(response);
            }
            return BadRequest();
        }

        [Authorize()]
        [HttpGet]
        [Route("GetLoans")]
        public async Task<IActionResult> GetLoans([FromQuery] GetLoansRequest request)
        {
            var response = await _loanService.GetLoans(request);
            if(response == null)
            {
                return BadRequest();
            }
            return Ok(response);
        }

        [Authorize()]
        [HttpGet]
        [Route("GetLoanById")]
        public async Task<IActionResult> GetLoanById([FromQuery] GetLoanByIdRequest request) 
        {
            var response = await _loanService.GetLoanById(request);
            if(response != null)
            {
                return Ok(response);
            }
            return null;
        }

        [Authorize()]
        [HttpDelete]
        [Route("DeleteLoan")]
        public async Task<IActionResult> DeleteLoan([FromQuery] DeleteLoanRequest request)
        {
            var response = await _loanService.DeleteLoan(request);
            if (response.Succsess)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [Authorize()]
        [HttpPut]
        [Route("UpdateLoan")]
        public async Task<IActionResult> UpdateLoan([FromQuery] UpdateLoanRequest request)
        {
            var response = await _loanService.UpdateLoan(request);
            if (response.Succsess)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
    }

}
