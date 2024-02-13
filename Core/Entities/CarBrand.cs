using System;

namespace Core.Entities
{
    public class CarBrand: BaseEntity
    {
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public bool IsRemoved { get; set; }
    }
}
