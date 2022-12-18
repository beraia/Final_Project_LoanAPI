using Azure.Core;
using Final_Project_LoanAPI.Data;
using Final_Project_LoanAPI.Models;
using Final_Project_LoanAPI.Services.Models.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Final_Project_LoanAPI.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _dbContext;

        public UserService(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration, ApplicationDbContext dbContext)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _dbContext = dbContext;
        }

        public async Task<BlockUserResponse> BlockUser(BlockUserRequest request)
        {
            var id = request.Id;
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);

            if(user != null)
            {
                user.IsBlocked = true;
                await _dbContext.SaveChangesAsync();
                return new BlockUserResponse() { Succsess = true };
            }
            return new BlockUserResponse() { Succsess = false };

        }

        public async Task<LoginResponse> Login(LoginRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);

            if(user!= null && user.IsBlocked)
            {
                return new LoginResponse() { Succsess = false, Message = "User is blocked" };
            }

            if (user != null && await _userManager.CheckPasswordAsync(user, request.Password))
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var token = GetToken(authClaims);

                return new LoginResponse
                {
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                    Expiration = token.ValidTo,
                };
            }
            return null;
        }

        public async Task<RegisterResponse> Register(RegisterRequest request)
        {
            var userExist = await _userManager.FindByNameAsync(request.UserName);
            if (userExist != null)
            {
                return new RegisterResponse() { Succsess = false, Message = "User allready exist" };
            }

            User user = new()
            {
                UserName = request.UserName,
                Email = request.Email
            };

            var result = await _userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
            {
                return new RegisterResponse() { Succsess = false, Message = "User cannot be created" };
            }

            return new RegisterResponse() { Succsess = true, Message = "Congratulations, your account has been successfully created." };
        }

        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }

        //public async Task CreateAccountant()
        //{
        //    User user = new()
        //    {
        //        UserName = "Accountant",
        //        Email = "accountant@gmail.com"
        //    };

        //    await _roleManager.CreateAsync(new IdentityRole { Name = "Accountant" });

        //    var result = await _userManager.CreateAsync(user, "qwerty1234567890");

        //    await _userManager.AddToRoleAsync(user, "Accountant");
        //}
    }
}
