using Core.Models.LoanModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces.Core
{
    public interface IFieldValueService
    {
        Task GenerateFieldValue(int loanTemplateId, int loanId);
        Task<FieldValueUpdateresponse> UpdateFieldValueAsync(FieldValueDTO fieldValueDTO);
        Task<string> GetValueFromLoanByKey(string key, int loanId);
    }
}
