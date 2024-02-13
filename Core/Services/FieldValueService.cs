using Core.CustomException;
using Core.Entities;
using Core.Interfaces.Core;
using Core.Interfaces.Infrastructure;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Models.LoanModels;
using Core.Interfaces.Core.CustomValidation;
using System.Linq;
using Core.Enums;
using Core.FieldValueValidation;
using Core.Interfaces.Core.CustomValidation.Providers;
using Core.Interfaces.Core.CustomValidation.Operators;

namespace Core.Services
{
    public class FieldValueService : IFieldValueService
    {
        private readonly IRepositoryProvider _repositoryProvider;
        private readonly IFieldValueValidator _validator;
        public FieldValueService(IRepositoryProvider repositoryProvider,
            IFieldValueValidator validator,
            IFieldValueProvider fieldValueProvider)
        {
            _repositoryProvider = repositoryProvider;
            _validator = validator;
        }

        public async Task GenerateFieldValue(int loanTemplateId, int loanId)
        {
            List<int> fieldIds = await _repositoryProvider.LoanTemplates.GetFieldIdListAsync(loanTemplateId);

            foreach (var id in fieldIds)
            {
                var fieldvalue = new FieldValue
                {
                    Value = string.Empty,
                    FieldId = id,
                    LoanId = loanId
                };

                await _repositoryProvider.FieldValues.CreateAsync(fieldvalue);
            }

            await _repositoryProvider.SaveAsync();
        }

        //Test Method
        public async Task<string> GetValueFromLoanByKey(string key, int loanId)
        {
            var fieldValue = await _repositoryProvider.FieldValues.GetFieldValueFromLoanByKey(key, loanId);
            return fieldValue.Value;
        }

        public async Task<FieldValueUpdateresponse> UpdateFieldValueAsync(FieldValueDTO fieldValueDTO)
        {
            await _validator.Validate(fieldValueDTO);

            FieldValue fieldValue = await _repositoryProvider.FieldValues.GetByIdAsync(fieldValueDTO.Id ?? default);

            if (fieldValue is null)
            {
                throw new FieldValueNotFoundException("FieldValue with this id doesn't exist");
            }

            fieldValue.Value = fieldValueDTO.Value;
            await _repositoryProvider.SaveAsync();

            var response = new FieldValueUpdateresponse
            {
                Id = fieldValueDTO.Id ?? default,
                Value = fieldValueDTO.Value,
                SectionId = fieldValue.Field.SectionId
            };

            return response;
        }

    }
}
