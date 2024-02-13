using System.Collections.Generic;

namespace Core.Models.LoanTemplate
{
    public class LoanTemplateCreateDTO
    {
        public string Name { get; set; }
        public IList<SectionDTO> Sections { get; set; }
    }
}
