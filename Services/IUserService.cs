using Final_Project_LoanAPI.Services.Models.Login;
using Final_Project_LoanAPI.Services.Models.Register;
using Microsoft.AspNetCore.Mvc;

namespace Final_Project_LoanAPI.Services
{
    public interface IUserService
    {
        Task<LoginResponse> Login(LoginRequest request);
        Task<RegisterResponse> Register(RegisterRequest request);
    }
}