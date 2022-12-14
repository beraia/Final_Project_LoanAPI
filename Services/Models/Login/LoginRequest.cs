using System.ComponentModel.DataAnnotations;

namespace Final_Project_LoanAPI.Services.Models.Login
{
    public class LoginRequest
    {
        [Required(ErrorMessage = "User Name is required")]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }
    }
}
