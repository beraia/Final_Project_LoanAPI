using System.ComponentModel.DataAnnotations;

namespace Final_Project_LoanAPI.Services.Models.User
{
    public class RegisterRequest
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public int Age { get; set; }

        public decimal Salary { get; set; }

    }

    public class RegisterResponse
    {
        public bool Succsess { get; set; }
        public string Message { get; set; }
    }
}
