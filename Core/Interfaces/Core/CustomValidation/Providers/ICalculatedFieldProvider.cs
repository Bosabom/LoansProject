using Core.Enums;

namespace Core.Interfaces.Core.CustomValidation.Providers
{
    public interface ICalculatedFieldProvider
    {
        IGeneralCalculatedOperator GetCalculatedOperator(OperationType operationType, IFieldValueProvider fieldValueProvider);
    }
}
