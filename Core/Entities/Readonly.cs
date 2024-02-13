using Core.Enums;

namespace Core.Entities
{
    public class Readonly
    {
        public ReadonlyType Type { get; set; }
        public bool Value { get; set; }
        public Condition Condition { get; set; }
    }
}
