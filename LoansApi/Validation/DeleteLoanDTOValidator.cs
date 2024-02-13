using Core.Models.LoanModels;
using FluentValidation;

namespace LoansApi.Validation
{
    public class DeleteLoanDTOValidator: AbstractValidator<DeleteLoanDTO>
    {
        public DeleteLoanDTOValidator()
        {
            RuleFor(x => x.Ids).NotEmpty();
        }
    }
}
