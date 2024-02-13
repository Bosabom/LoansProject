using Core.Entities;
using Core.Models.LoanTemplate;
using System.Linq;

namespace Core.Extensions.LoanTemplateJsons
{
    public static class SectionDTOToEntity
    {
        public static Section ToEntity(this SectionDTO sectionDTO)
        {
            var entity = new Section
            {
                Title = sectionDTO.Title,
                Fields = sectionDTO.Fields.Select(x => x.ToEntity()).ToList()
            };
            return entity;
        }
    }
}
