using Final_Project_LoanAPI.Services.Models.User;

namespace Final_Project_LoanAPI.Services
{
    public interface IUserService
    {
        Task<Login.Response> Login(Login.Request request);

        Task<Register.Response> Register(Register.Request request);
    }
}