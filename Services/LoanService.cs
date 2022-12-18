using Final_Project_LoanAPI.Data;
using Final_Project_LoanAPI.Models;
using Final_Project_LoanAPI.Services.Models.Loan;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Final_Project_LoanAPI.Services
{

    public class LoanService : ILoanService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<User> _userManager;

        public LoanService(ApplicationDbContext dbContext, IHttpContextAccessor httpContextAccessor, UserManager<User> userManager)
        {
            _dbContext = dbContext;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }

        public async Task<CreateLoanResponse> CreateLoan(CreateLoanRequest request)
        {
            var username = _httpContextAccessor.HttpContext.User.Identity.Name;

            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.UserName == username);

            if(user.IsBlocked)
            {
                return new CreateLoanResponse() { Succsess = false, Message = "User is blocked" };
            }

            Loan loan = new()
            {
                User = user,
                LoanType = request.LoanType,
                LoanPeriod = request.LoanPeriod,
                Ammount = request.Ammount,
                Currency = request.Currency
            };

            if (loan.LoanPeriod > 1 && loan.Currency != null && loan.Ammount > 50 && loan.LoanType != null)
            {
                _dbContext.Loans.Add(loan);
                _dbContext.SaveChanges();
                return new CreateLoanResponse() { Succsess = true, Message = "Added" };
            }
            return new CreateLoanResponse() { Succsess = false, Message = "" };

        }

        public async Task<GetLoansResponse> GetLoans(GetLoansRequest request)
        {
            var username = _httpContextAccessor.HttpContext.User.Identity.Name;

            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.UserName == username);

            var loansQuery = _dbContext.Loans.Select(x => x);
            if(!await _userManager.IsInRoleAsync(user, "Accountant"))
            {
                loansQuery = loansQuery.Where(x => x.User.Id == user.Id);
            }

            var loans = loansQuery.Select(x => new GetLoansResponse.Loan
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

        public async Task<DeleteLoanResponse> DeleteLoan(DeleteLoanRequest request)
        {
            var id = request.Id;
            var loan = await _dbContext.Loans.FirstOrDefaultAsync(x => request.Id == id);

            if(loan == null)
            {
                return new DeleteLoanResponse() { Succsess = false, Message = "Wrong id" };
            }
            _dbContext.Loans.Remove(loan);
            await _dbContext.SaveChangesAsync();
            return new DeleteLoanResponse() { Succsess = true, Message = "Deleted" };
        }

        public async Task<UpdateLoanResponse> UpdateLoan(UpdateLoanRequest request)
        {
            var id = request.Id;
            var loan = await _dbContext.Loans.FirstOrDefaultAsync(x => request.Id == id);
            if (loan == null)
            {
                return new UpdateLoanResponse() { Succsess = false, Message = "Wrong id" };
            }
            return new UpdateLoanResponse() { Succsess = true, Message = "The loan was successfully renewed" };
        }
    }
}