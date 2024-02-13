using Core.Entities;
using Core.Models.LoanModels;
using System.Threading.Tasks;

namespace Core.Interfaces.Infrastructure
{
    public interface IFieldValueRepository: IGenericRepository<FieldValue>
    {
        Task<FieldValue> GetFieldValueFromLoanByKey(string key, int loanId);
        Task<FieldFullDataDTO> GetFieldFullData(int fieldId, int loanId);
    }
}
