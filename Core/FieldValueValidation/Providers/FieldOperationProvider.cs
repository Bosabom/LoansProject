using Core.Enums;
using Core.FieldValueValidation.OperationValidators;
using Core.Interfaces.Core.CustomValidation;
using Core.Interfaces.Core.CustomValidation.Providers;
using System.Collections.Generic;

namespace Core.FieldValueValidation.Providers
{
    public class FieldOperationProvider : IFieldOperationProvider
    {
        public IGeneralConditionOperator GetOperationOperator(OperationType operationType, IFieldValueProvider fieldValueProvider )
        {
            var operationProviders = new Dictionary<OperationType, IGeneralConditionOperator> {
                { OperationType.MoreThanOrEquals, new MoreThanOrEqualsOperator(fieldValueProvider)}
            };

            return operationProviders[operationType];
        }
    }
}
