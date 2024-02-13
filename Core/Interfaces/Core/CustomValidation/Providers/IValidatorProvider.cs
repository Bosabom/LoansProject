using Core.Enums;
using System.Threading.Tasks;

namespace Core.Interfaces.Core.CustomValidation.Providers
{
    public interface IValidatorProvider
    {
        Task<IGeneralFieldTypeValidator> GetValidator(ValidationType type);
    }
}
