using Core.Models.Base;
using System.Collections.Generic;

namespace Core.Models.LoanTemplate
{
    public class LoanTemplateDTO: BaseDTO
    {
        public string Name { get; set; }
        public IList<SectionDTO> Sections { get; set; }
    }
}
