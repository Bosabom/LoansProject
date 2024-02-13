using Core.Entities;
using Core.Extensions.LoanTemplateJsons;
using Core.Models.LoanTemplate;
using System.Linq;

namespace Core.Extensions.LoanTemplates
{
    public static class LoanTemplateToDTO
    {
        public static LoanTemplateDTO ToDTO(this LoanTemplate loanTemplate)
        {
            var templateDTO = new LoanTemplateDTO
            {
                 Id = loanTemplate.Id,
                 CreationDate = loanTemplate.CreationDate,
                 Name = loanTemplate.Name,
                 Sections = loanTemplate.Sections.Select(x=>x.ToDTO()).ToList()
            };
            return templateDTO;
        }
    }
}
