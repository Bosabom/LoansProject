
using Core.Entities;

namespace Core.Models.LoanTemplate
{
    public class LoanTemplateSummaryResponse
    {
        public PaginatedList<LoanTemplateSummaryDTO> TemplateSummaryDTOs { get; set; }
        public int TotalCount { get; set; }
    }
}
