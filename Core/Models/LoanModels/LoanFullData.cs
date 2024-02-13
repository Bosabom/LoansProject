using Core.Enums;
using Core.Models.LoanTemplate;
using System.Collections.Generic;

namespace Core.Models.LoanModels
{
    public class LoanFullData
    {
        public int Id { get; set; }
        public string LoanTemplateName { get; set; }
        public int LoanTemplateId { get; set; }
        public LoanStatus Status { get; set; }
        public List<SectionFullData> Sections { get; set; } = new List<SectionFullData>();
    }
}
