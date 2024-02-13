using Core.Enums;
using System;

namespace Core.Models.LoanModels
{
    public class LoanSummaryDTO
    {
        public int Id { get; set; }
        public string LoanTemplateName { get; set; }
        public int LoanTemplateId { get; set; }
        public DateTime RequestDate { get; set; }
        public LoanStatus Status { get; set; }
    }
}
