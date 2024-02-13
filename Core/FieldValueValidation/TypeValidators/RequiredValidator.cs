using Core.CustomException.FieldValueValidation;
using Core.Entities;
using Core.Interfaces.Core.CustomValidation;
using System.Threading.Tasks;

namespace Core.FieldValueValidation.TypeValidators
{
    public class RequiredValidator : IGeneralFieldTypeValidator
    {
        public async Task ValidateType(int loanId, string value, Validation validation)
        {
            var result = await Task.Run(() => string.IsNullOrEmpty(value));

            if (result)
            {
                throw new FieldValueValidationException("Value can't be null");
            }

        }
    }
}