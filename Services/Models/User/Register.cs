using System.ComponentModel.DataAnnotations;

namespace Final_Project_LoanAPI.Services.Models.User
{
    public class RegisterRequest
    {
        [Required(ErrorMessage = "First Name is required")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "User Name is required")]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Age is required")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Salary is required")]
        public decimal Salary { get; set; }

        [Required(ErrorMessage = "Required")]
        public bool IsBlocked { get; set; }
    }

    public class RegisterResponse
    {
        public bool Succsess { get; set; }
        public string Message { get; set; }
    }
}
