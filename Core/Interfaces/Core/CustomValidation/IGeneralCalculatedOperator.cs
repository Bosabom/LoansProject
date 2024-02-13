using Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces.Core.CustomValidation
{
    public interface IGeneralCalculatedOperator
    {
        Task<int> MakeOperation(int loanId, string value, IList<Value> values);
    }
}
