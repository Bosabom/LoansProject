using Core.Entities;
using Core.Enums;
using Core.Models.LoanModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces.Infrastructure
{
    public interface ILoanRepository: IGenericRepository<Loan>
    {
        //Task<LoanFullDataDTO> GetFullDataAsync(int id);
        Task<LoanFullData> GetFullDataAsync(int id);
        Task<List<List<FieldFullDataDTO>>> GetListOfFields(int templateId, int loanId);
        Loan MarkAsRemoved(Loan loan);
        Task<LoanSummaryResponse> GetFilteredLoansAsync(IEnumerable<LoanStatus> selectedStatuses, string searchString,
            string orderByColumn, int pageSize, SortOrder order, int pageIndex);
    }
}
