using Core.Models.LoanTemplate;
using FluentValidation;

namespace LoansApi.Validation
{
    public class LoanTemplateValidator : AbstractValidator<LoanTemplateCreateDTO>
    {
        public LoanTemplateValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(1000);
            RuleFor(x => x.Sections).Must(x=>x.Count == 3)
                .WithMessage("This field must contain 3 sections");
        }
    }
}
