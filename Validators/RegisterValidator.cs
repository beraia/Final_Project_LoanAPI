﻿using Final_Project_LoanAPI.Services.Models.User;
using FluentValidation;

namespace Final_Project_LoanAPI.Validators
{
    public class RegisterValidator : AbstractValidator<RegisterRequest>
    {
        public RegisterValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("Name is empty").Length(2, 20).WithMessage("Length is not correct");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Lastname is empty").Length(2, 20).WithMessage("Length is not correct");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Username is empty").Length(2, 20).WithMessage("Length is not correct");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is empty").Length(2, 20).WithMessage("Length is not correct");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is empty").Length(2, 20).WithMessage("Length is not correct");
            RuleFor(x => x.Age).NotEmpty().WithMessage("Age is not correct");
            RuleFor(x => x.Salary).GreaterThan(0).WithMessage("The salary amount is not correct");
        }
    }
}
