using Core.Enums;
using Core.FieldValueValidation.TypeValidators;
using Core.Interfaces.Core.CustomValidation;
using Core.Interfaces.Core.CustomValidation.Operators;
using Core.Interfaces.Core.CustomValidation.Providers;
using Core.Interfaces.Infrastructure;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.FieldValueValidation.Providers
{
    public class ValidatorProvider : IValidatorProvider
    {
        private readonly IFieldOperationProvider _operationProvider;
        private readonly IFieldValueProvider _fieldValueProvider;
        public ValidatorProvider(IFieldOperationProvider operationProvider,
            IFieldValueProvider fieldValueProvider)
        {
            _operationProvider = operationProvider;

            _fieldValueProvider = fieldValueProvider;
        }

        public async Task<IGeneralFieldTypeValidator> GetValidator(ValidationType type)
        {
            var validators = new Dictionary<ValidationType, IGeneralFieldTypeValidator> {
                { ValidationType.Required, new RequiredValidator() },
                { ValidationType.Min, new MinValidator()},
                { ValidationType.Max, new MaxValidator()},
                { ValidationType.Maxlength, new MaxLengthValidator()},
                { ValidationType.Condition, new ConditionValidator(_operationProvider, _fieldValueProvider)}
            };
            var validator = await Task.Run(()=> validators[type]);

            return validator;
        }
    }
}
