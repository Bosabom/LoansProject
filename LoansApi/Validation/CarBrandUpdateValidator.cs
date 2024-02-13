using Core.Models.CarBrand;
using FluentValidation;

namespace LoansApi.Validation
{
    public class CarBrandUpdateValidator: AbstractValidator<CarBrandUpdate>
    {
        public CarBrandUpdateValidator()
        {
            RuleFor(x=>x.Id).NotEmpty();
            RuleFor(x => x.Name).NotEmpty().WithMessage("{PropertyName} shouldn't be empty.");
        }
    }
}
