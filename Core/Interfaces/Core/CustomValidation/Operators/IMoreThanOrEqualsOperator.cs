using Core.Entities;
using Core.Models.LoanModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Interfaces.Core.CustomValidation.Operators
{
    public interface IMoreThanOrEqualsOperator
    {
        bool MakeOperation(FieldValueDTO fieldValueDTO, Validation validation);
    }
}
