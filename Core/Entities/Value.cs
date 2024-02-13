using Core.Enums;

namespace Core.Entities
{
    public class Value
    {
        public ValueType Type { get; set; }
        public string Key { get; set; }
        public int Order { get; set; }
    }
}
