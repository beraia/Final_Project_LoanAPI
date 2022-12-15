using System.ComponentModel.DataAnnotations;

namespace Final_Project_LoanAPI.Services.Models.User
{
    public class Login
    {
        public class Request
        {
            [Required(ErrorMessage = "User Name is required")]
            public string? UserName { get; set; }

            [Required(ErrorMessage = "Password is required")]
            public string? Password { get; set; }
        }

        public class Response
        {
            public string Token { get; set; }
            public DateTime Expiration { get; set; }
        }
    }
}
