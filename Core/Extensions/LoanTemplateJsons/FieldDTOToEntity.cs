using Core.Entities;
using Core.Models.LoanTemplate;
using System.Linq;

namespace Core.Extensions.LoanTemplateJsons
{
    public static class FieldDTOToEntity
    {
        public static Field ToEntity(this FieldDTO fieldDTO)
        {
            var entity = new Field
            {
                Key = fieldDTO.Key,
                Title = fieldDTO.Title,
                Type = fieldDTO.Type,
                Validation = fieldDTO.Validation.Select(x => x.ToEntity()).ToList(),
                Readonly = fieldDTO?.Readonly,
                Calculated = fieldDTO.Calculated,
                Options = fieldDTO.Options,
                OptionsUrl = fieldDTO.OptionsUrl
            };
            return entity;
        }
    }
}
