using Core.CustomException;
using Core.Interfaces.Core.CustomValidation;
using Core.Interfaces.Core.CustomValidation.Providers;
using Core.Interfaces.Infrastructure;
using Core.Models.LoanModels;
using System.Threading.Tasks;

namespace Core.FieldValueValidation
{
    public class FieldValueValidator : IFieldValueValidator
    {
        private readonly IRepositoryProvider _repositoryProvider;
        private readonly IValidatorProvider _validatorProvider;
        private readonly IFieldValueProvider _fieldValueProvider;

        public FieldValueValidator(IRepositoryProvider repositoryProvider,
            IValidatorProvider validatorProvider,
            IFieldValueProvider fieldValueProvider)
        {
            _repositoryProvider = repositoryProvider;
            _validatorProvider = validatorProvider;
            _fieldValueProvider = fieldValueProvider;
        }

        public async Task Validate(FieldValueDTO fieldValueDTO)
        {
            if (fieldValueDTO.Id is null)
            {
                throw new FieldValueNotFoundException("Id can't be empty");
            }
            if (fieldValueDTO.FieldId is null)
            {
                throw new FieldValueNotFoundException("Id of field can't be empty");
            }
            if (fieldValueDTO.LoanId is null)
            {
                throw new FieldValueNotFoundException("LoanId can't be null");
            }

            var fieldFullData = await _repositoryProvider.FieldValues.GetFieldFullData(fieldValueDTO.FieldId ?? default, fieldValueDTO.LoanId ?? default);

            if (fieldFullData is null)
            {
                throw new FieldValueNotFoundException("Id of field doesn't exist");
            }

            var compositekey = $"{fieldValueDTO.LoanId}_{fieldFullData.Key}";
            await _fieldValueProvider.Add(compositekey, fieldValueDTO.Value);

            foreach (var validation in fieldFullData.Validation)
            {
                var validator = await _validatorProvider.GetValidator(validation.Type);
                await validator.ValidateType(fieldValueDTO.LoanId ?? default, fieldValueDTO.Value, validation);
            }
        }
    }
}
