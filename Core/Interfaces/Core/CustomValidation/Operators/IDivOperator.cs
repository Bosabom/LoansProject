using Core.Entities;
using Core.Models.LoanModels;

namespace Core.Interfaces.Core.CustomValidation.Operators
{
    public interface IDivOperator
    {
        int MakeOperation(FieldValueDTO fieldValueDTO, Validation validation);
    }
}
