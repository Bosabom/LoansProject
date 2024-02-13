using Core.Entities;
using Core.Models.LoanTemplate;

namespace Core.Extensions.LoanTemplateJsons
{
    public static class ValidationDTOToEntity
    {
        public static Validation ToEntity(this ValidationDTO validationDTO)
        {
            var entity = new Validation
            {
                Type = validationDTO.Type,
                Value = validationDTO.Value,
                Condition = validationDTO.Condition,
                Message = validationDTO.Message
            };
            return entity;
        }
    }
}
