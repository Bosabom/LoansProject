using Core.Entities;
using Core.Interfaces.Core.CustomValidation;
using Core.Interfaces.Core.CustomValidation.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.FieldValueValidation.OperationValidators
{
    public class DivOperator : IGeneralCalculatedOperator
    {
        private readonly IFieldValueProvider _fieldValueProvider;
        public DivOperator(IFieldValueProvider fieldValueProvider)
        {
            _fieldValueProvider = fieldValueProvider;
        }

        public async Task<int> MakeOperation(int loanId, string value, IList<Value> values)
        {
            var orderedValues = values.OrderBy(x => x.Order)
                .ToList();

            var firstKey = orderedValues[0].Key;
            var secondKey = orderedValues[1].Key;

            var firstValue = await _fieldValueProvider.GetValue(loanId, value, firstKey);
            var secondValue = await _fieldValueProvider.GetValue(loanId, value, secondKey);


            if (Int32.TryParse(firstValue, out int firstValueInt) && Int32.TryParse(secondValue, out int secondValueInt))
            {
                var result = firstValueInt / secondValueInt;

                return result;
            }
            return 0;
        }
    }
}
