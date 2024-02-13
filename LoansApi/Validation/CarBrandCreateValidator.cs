using Core.Models.CarBrand;
using FluentValidation;

namespace LoansApi.Validation
{
    public class CarBrandCreateValidator: AbstractValidator<CarBrandCreate>
    {
        public  CarBrandCreateValidator()
        {
            RuleFor(x=>x.Name).NotEmpty().WithMessage("{PropertyName} shouldn't be empty.");
        }
    }
}
