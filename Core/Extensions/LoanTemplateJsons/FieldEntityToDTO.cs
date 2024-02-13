using Core.Entities;
using Core.Models.LoanTemplate;
using System.Linq;

namespace Core.Extensions.LoanTemplateJsons
{
    public static class FieldEntityToDTO
    {
        public static FieldDTO ToDTO(this Field field)
        {
            var model = new FieldDTO
            {
                Id = field.Id,
                Key = field.Key,
                Title = field.Title,
                Type = field.Type,
                Validation = field.Validation.Select(x => x.ToDTO()).ToList(),
                Readonly = field?.Readonly,
                Calculated = field.Calculated,
                Options = field.Options,
                OptionsUrl = field.OptionsUrl
            };
            return model;
        }
    }
}
