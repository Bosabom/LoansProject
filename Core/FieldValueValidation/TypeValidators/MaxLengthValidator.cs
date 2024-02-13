using Core.CustomException.FieldValueValidation;
using Core.Entities;
using Core.Interfaces.Core.CustomValidation;
using Core.Models.LoanModels;
using System.Threading.Tasks;

namespace Core.FieldValueValidation.TypeValidators
{
    public class MaxLengthValidator : IGeneralFieldTypeValidator
    {
        public async Task ValidateType(int loanId, string value, Validation validation)
        {
            var result = await Task.Run(() => (value.Length > validation.Value));
            if (result)
            {
                throw new FieldValueValidationException($"Length can't be more then {validation.Value}");
            }
        }
    }
}
