using Final_Project_LoanAPI.Services;
using Final_Project_LoanAPI.Services.Models;
using Final_Project_LoanAPI.Services.Models.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
        [Route("Login")]
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
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            var response = await _userService.Register(request);
            if (response.Succsess)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPut]
        [Authorize (Roles = UserRoles.Accountant)]
        [Route("Block/{id}")]
        public async Task<IActionResult> BlockUser([FromBody] string id)
        {
            var response = await _userService.BlockUser(new BlockUserRequest { Id = id});
            if (response.Succsess)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        //[AllowAnonymous]
        //[HttpPost]
        //[Route("CreateAccountant")]
        //public async Task<IActionResult> CreateAccountant()
        //{
        //    await _userService.CreateAccountant();
        //    return Ok();
        //}
    }
}
