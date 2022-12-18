# Final_Project_LoanAPI

Banking application with Accountant and User roles.

Several methods are described in the application.

[HttpPost] [AllowAnonymous] Login - User authorization.

[HttpPost] [AllowAnonymous] Register - Create a new user.

[HttpPost] [Authorize (Roles = UserRoles.Accountant)] BlockUser - A user with the Accountant role can block a user with a given ID.

[HttpPost] [Authorize] CreateLoan - An authorized user can add a loan.

[HttpGet] [Authorize] GetLoans - A user with the role of Accountant can receive information about all loans in the database.

[HttpGet] GetLoanById - View information about a loan with a transferred Id.

[HttpDelete] [Authorize] DeleteLoan - An authorized user can delete his own loan if the loan is not in process.
                                      Accountant can delete any loan with transferred Id.
                                      
[HttpPut] [Authorize] UpdateLoan - Authorized users can update their loan details if the loan is not in process.
                                    The Accountant can change the data of any loan with the transferred Id.
