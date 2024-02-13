using Core.Entities;
using Core.Models.LoanTemplate;

namespace Core.Extensions.LoanTemplateJsons
{
    public static class ValidationEntityToDTO
    {
        public static ValidationDTO ToDTO(this Validation validation)
        {
            var model = new ValidationDTO
            {
                Type = validation.Type,
                Value = validation.Value,
                Message = validation.Message,
                Condition = validation.Condition
            };
            return model;
        }
    }
}
