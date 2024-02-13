using Core.Models.LoanModels;
using FluentValidation;

namespace LoansApi.Validation
{
    public class LoanValidator : AbstractValidator<LoanCreateRequest>
    {
        public LoanValidator()
        {
            RuleFor(x => x.LoanTemplateId).NotEmpty();
            RuleFor(x => x.LoanTemplateName).NotEmpty().WithMessage("{PropertyName} shouldn't be empty.");
        }
    }
}
