using Core.Entities;
using Core.Enums;
using Core.Models.LoanModels;
using Core.Models.LoanTemplate;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces.Infrastructure
{
    public interface ILoanTemplateRepository: IGenericRepository<LoanTemplate>
    {
        Task<LoanTemplate> GetWithDetailsByIdAsync(int id);
        Task<List<int>> GetFieldIdListAsync(int id);
        LoanTemplate MarkAsRemoved(LoanTemplate template);
        Task<LoanTemplateSummaryResponse> GetFilteredTemplatesAsync(string searchString,
            string orderByColumn, int pageSize, SortOrder order, int pageIndex);
    }
}
