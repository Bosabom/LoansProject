using Core.Entities;
using Core.Models.LoanTemplate;
using System.Linq;

namespace Core.Extensions.LoanTemplateJsons
{
    public static class SectionEntityToDTO
    {
        public static SectionDTO ToDTO(this Section section)
        {
            var model = new SectionDTO
            {
                Title = section.Title,
                Fields = section.Fields.Select(x => x.ToDTO()).ToList(),
                Id = section.Id
            };
            return model;
        }
    }
}
