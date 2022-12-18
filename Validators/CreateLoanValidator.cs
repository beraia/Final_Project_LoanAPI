using Final_Project_LoanAPI.Services.Models.Loan;
using FluentValidation;

namespace Final_Project_LoanAPI.Validators
{
    public class CreateLoanValidator : AbstractValidator<CreateLoanRequest>
    {
        public CreateLoanValidator()
        {
            RuleFor(x => x.LoanType).NotEmpty().WithMessage("Select Loan Type");
            RuleFor(x => x.Currency).NotEmpty().WithMessage("Currency is empty");
            RuleFor(x => x.LoanPeriod).NotEmpty().WithMessage("Loan period is not correct");
            RuleFor(x => x.Ammount).NotEmpty().WithMessage("Ammount is not correct");
        }
    }
}
