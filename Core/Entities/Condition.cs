using Core.Enums;
using System.Collections.Generic;

namespace Core.Entities
{
    public class Condition
    {
        public OperationType Operation { get; set; }
        public IList<Value> Values { get; set; } = new List<Value>();
    }
}
