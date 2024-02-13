using Core.Enums;

namespace Core.Interfaces.Core.CustomValidation.Providers
{
    public interface IFieldOperationProvider
    {
        IGeneralConditionOperator GetOperationOperator(OperationType operationType, IFieldValueProvider fieldValueProvider);
    }
}
