using Core.Models.LoanTemplate;
using FluentValidation;

namespace LoansApi.Validation
{
    public class DeleteLoanTemplateDTOValidator: AbstractValidator<DeleteLoanTemplateDTO>
    {
        public DeleteLoanTemplateDTOValidator()
        {
            RuleFor(x => x.Ids).NotEmpty();
        }
    }
}
