using Core.Entities;
using Core.Extensions.LoanTemplateJsons;
using Core.Models.LoanTemplate;
using System;
using System.Linq;

namespace Core.Extensions.LoanTemplates
{
    public static class LoanTemplateDTOToEntity
    {
        public static LoanTemplate ToEntity(this LoanTemplateCreateDTO createDTO)
        {
            var loanTemplate = new LoanTemplate
            {
                 Name = createDTO.Name,
                 CreationDate = DateTime.Now,
                 Sections = createDTO.Sections.Select(x=>x.ToEntity()).ToList()
            };
            return loanTemplate;
        }
    }
}
