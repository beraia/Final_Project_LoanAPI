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

        [Authorize]
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateLoan([FromQuery] CreateLoanRequest request)
        {
            try
            {
                var response = await _loanService.CreateLoan(request);
                if (response.Succsess)
                {
                    return Ok(response);
                }
                return BadRequest();
            }
            catch (Exception)
            {

                return StatusCode(500, "Server Error");
            }
        }

        [Authorize]
        [HttpGet]
        [Route("GetLoans")]
        public async Task<IActionResult> GetLoans([FromQuery] GetLoansRequest request)
        {
            try
            {
                var response = await _loanService.GetLoans(request);
                if (response == null)
                {
                    return BadRequest();
                }
                return Ok(response);
            }
            catch (Exception)
            {

                return StatusCode(500, "Server Error");
            }
        }

        [Authorize]
        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetLoanById([FromQuery] GetLoanByIdRequest request) 
        {
            try
            {
                var response = await _loanService.GetLoanById(request);
                if (response != null)
                {
                    return Ok(response);
                }
                return null;
            }
            catch (Exception)
            {

                return StatusCode(500, "Server Error");
            }
        }

        [Authorize]
        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> DeleteLoan([FromQuery] DeleteLoanRequest request)
        {
            try
            {
                var response = await _loanService.DeleteLoan(request);
                if (response.Succsess)
                {
                    return Ok(response);
                }
                return BadRequest(response);
            }
            catch (Exception)
            {
                return StatusCode(500, "Server Error");
            }
        }

        [Authorize]
        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> UpdateLoan([FromQuery] UpdateLoanRequest request)
        {
            try
            {
                var response = await _loanService.UpdateLoan(request);
                if (response.Succsess)
                {
                    return Ok(response);
                }
                return BadRequest(response);
            }
            catch (Exception)
            {

                return StatusCode(500, "Server Error");
            }
        }
    }

}
