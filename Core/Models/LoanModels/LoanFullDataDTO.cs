using Core.Enums;
using System.Collections.Generic;

namespace Core.Models.LoanModels
{
    public class LoanFullDataDTO
    {
        public int Id { get; set; }
        public string LoanTemplateName { get; set; }
        public LoanStatus Status { get; set; }
        public IList<FieldFullDataDTO> Fields { get; set; }
    }
}
