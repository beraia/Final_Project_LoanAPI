namespace Final_Project_LoanAPI.Services.Models.Login
{
    public class LoginResponse
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
