using Final_Project_LoanAPI.Services.Models.Loan;

namespace Final_Project_LoanAPI.Services
{
    public interface ILoanService
    {
        Task<CreateLoanResponse> CreateLoan(CreateLoanRequest request);

        Task<GetLoansResponse> GetLoans(GetLoansRequest request);

        Task<GetLoanByIdResponse> GetLoanById(GetLoanByIdRequest request);

        Task<DeleteLoanResponse> DeleteLoan(DeleteLoanRequest request);

        Task<UpdateLoanResponse> UpdateLoan(UpdateLoanRequest request);
    }
}