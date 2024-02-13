using Core.Entities;
using Core.Interfaces.Core.CustomValidation;
using Core.Models.LoanModels;
using System.Linq;
using Core.Interfaces.Core.CustomValidation.Providers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.FieldValueValidation.OperationValidators
{
    public class MoreThanOrEqualsOperator : IGeneralConditionOperator
    {
        private readonly IFieldValueProvider _fieldValueProvider;

        public MoreThanOrEqualsOperator(
            IFieldValueProvider fieldValueProvider)
        {
            _fieldValueProvider = fieldValueProvider;
        }

        public async Task<bool> MakeOperation(int loanId, string value, IList<Value> values)
        {
            var orderedValues = values.OrderBy(x => x.Order)
                .ToList();

            var firstKey = orderedValues[0].Key;
            var secondKey = orderedValues[1].Key;

            var firstValue = await _fieldValueProvider.GetValue(loanId, value, firstKey);
            var secondValue = await _fieldValueProvider.GetValue(loanId, value, secondKey);

            var firstValueSuccess = int.TryParse(firstValue, out int firstValueInt);
            var secondValueSucces = int.TryParse(secondValue, out int secondValueInt);

            return firstValueSuccess && secondValueSucces && firstValueInt < secondValueInt;
        }
    }
}
