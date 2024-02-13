using Core.CustomException.FieldValueValidation;
using Core.Entities;
using Core.Interfaces.Core.CustomValidation;
using System.Threading.Tasks;

namespace Core.FieldValueValidation.TypeValidators
{
    public class MaxValidator : IGeneralFieldTypeValidator
    {
        public async Task ValidateType(int loanId, string value, Validation validation)
        {
            var result = await Task.Run(() => (int.Parse(value) > validation.Value));
            if (result)
            {
                throw new FieldValueValidationException($"Value can't be more then {validation.Value}");
            }
        }
    }
}
