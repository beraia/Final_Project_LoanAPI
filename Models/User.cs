using Microsoft.AspNetCore.Identity;

namespace Final_Project_LoanAPI.Models
{
    public class User : IdentityUser
    {
        public int Age { get; set; }
        public decimal Salary { get; set; }
        public bool IsBlocked { get; set; } = false;
    }
}
