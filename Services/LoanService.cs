using Final_Project_LoanAPI.Data;
using Final_Project_LoanAPI.Models;
using Final_Project_LoanAPI.Services.Models.Loan;
using Microsoft.EntityFrameworkCore;

namespace Final_Project_LoanAPI.Services
{

    public class LoanService : ILoanService
    {
        private readonly ApplicationDbContext _dbContext;

        public LoanService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CreateLoanResponse> CreateLoan(CreateLoanRequest request)
        {
            Loan loan = new()
            {
                LoanType = request.LoanType,
                LoanPeriod = request.LoanPeriod,
                Ammount = request.Ammount,
                Currency = request.Currency
            };

            if (loan.LoanPeriod != null && loan.Currency != null && loan.Ammount != null)
            {
                _dbContext.Loans.Add(loan);
                _dbContext.SaveChanges();
                return new CreateLoanResponse() { Succsess = true, Message = "Added" };
            }
            return new CreateLoanResponse() { Succsess = false, Message = "fuuuuuuck" };

        }

        public async Task<GetLoansResponse> GetLoans(GetLoansRequest request)
        {
            var loans = _dbContext.Loans.Select(x => new GetLoansResponse.Loan
            {
                Ammount= x.Ammount,
                Currency = x.Currency,
                Id = x.Id,
                Status = x.Status,
                LoanPeriod = x.LoanPeriod,
                LoanType = x.LoanType
            });

            return new GetLoansResponse()
            {
                Succsess = true,
                Loans = loans.ToList()
            };
        }

        public async Task<GetLoanByIdResponse> GetLoanById(GetLoanByIdRequest request)
        {
            var id = request.Id;
            var loan = await _dbContext.Loans.FirstOrDefaultAsync(x => request.Id == id);

            if (loan == null)
            {
                return new GetLoanByIdResponse() { Succsess = false, Message = "Wrong id" };
            }
            return new GetLoanByIdResponse()
            {
                Id = loan.Id,
                LoanType = loan.LoanType,
                Ammount = loan.Ammount,
                Currency = loan.Currency,
                LoanPeriod = loan.LoanPeriod,
                Status = loan.Status
            };
        }
    }
}