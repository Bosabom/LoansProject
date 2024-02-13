using Core.CustomException;
using Core.CustomException.FieldValueValidation;
using Core.Entities;
using Core.Interfaces.Core.CustomValidation;
using Core.Interfaces.Core.CustomValidation.Providers;
using Core.Models.LoanModels;
using System.Threading.Tasks;

namespace Core.FieldValueValidation.TypeValidators
{
    public class ConditionValidator : IGeneralFieldTypeValidator
    {
        private readonly IFieldOperationProvider _operationProvider;
        private readonly IFieldValueProvider _fieldValueProvider;
        public ConditionValidator(IFieldOperationProvider operationProvider,
            IFieldValueProvider fieldValueProvider)
        {
            _operationProvider = operationProvider;
            _fieldValueProvider = fieldValueProvider;
        }

        public async Task ValidateType(int loanId, string value, Validation validation)
        {

            var result = await _operationProvider.GetOperationOperator(validation.Condition.Operation, _fieldValueProvider)
                    .MakeOperation(loanId, value, validation.Condition.Values);
            if (result)
            {
                throw new FieldValueValidationException($"{validation.Message}");
            }
        }
    }
}
