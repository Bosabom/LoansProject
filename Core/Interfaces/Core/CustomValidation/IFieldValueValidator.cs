using Core.Entities;
using Core.Models.LoanModels;
using System.Threading.Tasks;

namespace Core.Interfaces.Core.CustomValidation
{
    public interface IFieldValueValidator
    {
        Task Validate(FieldValueDTO fieldValueDTO);
    }
}
