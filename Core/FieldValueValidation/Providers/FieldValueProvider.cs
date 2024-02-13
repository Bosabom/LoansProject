using Core.CustomException.FieldValueValidation;
using Core.Entities;
using Core.Interfaces.Core.CustomValidation.Providers;
using Core.Interfaces.Infrastructure;
using Core.Models.LoanModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.FieldValueValidation.Providers
{
    public class FieldValueProvider : IFieldValueProvider
    {
        private readonly IRepositoryProvider _repositoryProvider;
        private readonly IFieldOperationProvider _fieldOperationProvider;
        private readonly ICalculatedFieldProvider _calculatedFieldProvider;

        public Dictionary<string, string> Values { get; set; } = new Dictionary<string, string>();
        public FieldValueProvider(
            IRepositoryProvider repositoryProvider,
            IFieldOperationProvider fieldOperationProvider,
            ICalculatedFieldProvider calculatedFieldProvider
            )
        {
            _repositoryProvider = repositoryProvider;
            _fieldOperationProvider = fieldOperationProvider;
            _calculatedFieldProvider = calculatedFieldProvider;
        }

        public async Task<string> GetValue(int loanId, string value, string key)
        {
            var compositeKey = $"{loanId}_{key}";

            if (this.Values.TryGetValue(compositeKey, out string cashedValue))
            {
                return cashedValue;
            }

            var valueFromDB = await _repositoryProvider.FieldValues.GetFieldValueFromLoanByKey(key, loanId);

            if (valueFromDB.Field.Calculated != null)
            {
                var calculatedOperator = _calculatedFieldProvider.GetCalculatedOperator(valueFromDB.Field.Calculated.Operation, this);
                var operationResult = await calculatedOperator.MakeOperation(loanId, value, valueFromDB.Field.Calculated.Values);
                await Add(compositeKey, operationResult.ToString());

                if (operationResult != 0 && valueFromDB.Field.Validation != null)
                {
                    foreach (var validation in valueFromDB.Field.Validation)
                    {
                        var validatorProvider = new ValidatorProvider(_fieldOperationProvider, this);
                        var validator = await validatorProvider.GetValidator(validation.Type);
                        await validator.ValidateType(loanId, operationResult.ToString(), validation);
                    }
                }
                return operationResult.ToString();
            }
            await Add(compositeKey, valueFromDB.Value);
            return valueFromDB.Value;
        }

        public async Task Add(string compositeKey, string value)
        {
            await Task.Run(()=> Values.TryAdd(compositeKey, value));
        }
    }
}
