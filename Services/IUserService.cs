using Final_Project_LoanAPI.Services.Models.User;

namespace Final_Project_LoanAPI.Services
{
    public interface IUserService
    {
        Task<LoginResponse> Login(LoginRequest request);

        Task<RegisterResponse> Register(RegisterRequest request);

        Task<BlockUserResponse> BlockUser(BlockUserRequest request);

        //Task CreateAccountant();
    }
}