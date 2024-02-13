using Core.CustomException.FieldValueValidation;
using Core.Entities;
using Core.Interfaces.Core.CustomValidation;
using System.Threading.Tasks;

namespace Core.FieldValueValidation.TypeValidators
{
    public class MinValidator : IGeneralFieldTypeValidator
    {
        public async Task ValidateType(int loanId, string value, Validation validation)
        {
            var result = await Task.Run(() => (int.Parse(value) < validation.Value));
            if (int.Parse(value) < validation.Value)
            {
                throw new FieldValueValidationException($"Value can't be less then {validation.Value}");
            }
        }
    }
}
