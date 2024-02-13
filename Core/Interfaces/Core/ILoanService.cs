using Core.Entities;
using Core.Enums;
using Core.Models.LoanModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces.Core
{
    public interface ILoanService
    {
        Task<int> CreateAsync(LoanCreateRequest request);
        Task ApplyAsync(int loanId);
        List<LoanSummaryDTO> GetAllAsync();
        Task MarkAsRemovedAsync(IEnumerable<int> ids);
        Task<LoanFullData> GetFullDataAsync(int id);

        Task<LoanSummaryResponse> GetFilteredLoansAsync(IEnumerable<LoanStatus> selectedStatuses,
            string searchString, string orderByColumn, int pageSize, SortOrder order, int pageIndex);
    }
}
