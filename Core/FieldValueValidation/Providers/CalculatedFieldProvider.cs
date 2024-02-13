using Core.Enums;
using Core.FieldValueValidation.OperationValidators;
using Core.Interfaces.Core.CustomValidation;
using Core.Interfaces.Core.CustomValidation.Providers;
using System.Collections.Generic;

namespace Core.FieldValueValidation.Providers
{
    public class CalculatedFieldProvider : ICalculatedFieldProvider
    {
        public IGeneralCalculatedOperator GetCalculatedOperator(OperationType operationType, IFieldValueProvider fieldValueProvider)
        {
            var operationProviders = new Dictionary<OperationType, IGeneralCalculatedOperator> {
                { OperationType.Div, new DivOperator(fieldValueProvider)}
            };

            return operationProviders[operationType];
        }
    }
}
