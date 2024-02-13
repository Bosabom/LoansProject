using Core.Entities;

namespace Core.Models.LoanModels
{
    public class LoanSummaryResponse
    {
        public PaginatedList<LoanSummaryDTO> LoanSummaryDTOs { get; set; }
        public int TotalCount { get; set; }
    }
}
