using Core.Enums;
using Core.Models.LoanTemplate;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces.Core
{
    public interface ILoanTemplateService
    {
        Task<LoanTemplateSummaryDTO> CreateAsync(LoanTemplateCreateDTO request);
        IList<LoanTemplateSummaryDTO> GetAllAsync();
        Task<LoanTemplateDTO> GetWithDetailsByIdAsync(int id);
        Task MarkAsRemoved(IEnumerable<int> selectedIds);
        Task<LoanTemplateSummaryResponse> GetFilteredTemplatesAsync(string searchString,
            string orderByColumn, int pageSize, SortOrder order, int pageIndex);
    }
}
