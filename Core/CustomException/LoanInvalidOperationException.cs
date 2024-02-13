using Core.Enums;
using System;

namespace Core.CustomException
{
    public class LoanInvalidOperationException : InvalidOperationException
    {
        public LoanInvalidOperationException(LoanStatus loanStatus) :
            base($"Your loan  request has `{loanStatus}` status. " +
                $"You can Apply loan request with status `{LoanStatus.InProcess}`")
        { }
        public LoanInvalidOperationException(string message) : base(message) { }
    }
}
