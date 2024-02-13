using Core.Models.LoanModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces.Core.CustomValidation.Providers
{
    public interface IFieldValueProvider
    {
        Task<string> GetValue(int loanId, string value, string key);
        Task Add(string compositeKey, string value);
        Dictionary<string, string> Values { get; }
    }
}
