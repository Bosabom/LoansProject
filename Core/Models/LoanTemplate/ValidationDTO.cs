using Core.Entities;
using Core.Enums;

namespace Core.Models.LoanTemplate
{
    public class ValidationDTO
    {
        public ValidationType Type { get; set; }
        public int Value { get; set; }
        public Condition Condition { get; set; }
        public string Message { get; set; }
    }
}
