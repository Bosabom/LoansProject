using Core.Entities;
using System.Threading.Tasks;

namespace Core.Interfaces.Core.CustomValidation
{
    public interface IGeneralFieldTypeValidator
    {
        Task ValidateType(int loanId, string value, Validation validation);
    }
}
