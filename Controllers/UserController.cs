using Final_Project_LoanAPI.Models;
using Final_Project_LoanAPI.Services;
using Final_Project_LoanAPI.Services.Models;
using Final_Project_LoanAPI.Services.Models.Login;
using Final_Project_LoanAPI.Services.Models.Register;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;
using System.Text;

namespace Final_Project_LoanAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var response = await _userService.Login(request);
            if(response == null)
            {
                return Unauthorized();
            }
            return Ok(response);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            var response = await _userService.Register(request);
            if (response.Succsess)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
    }
}
