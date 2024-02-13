using Core.Enums;

namespace Core.Entities
{
    public class Validation
    {
        public ValidationType Type { get; set; }
        public int Value { get; set; }
        public Condition Condition { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}
