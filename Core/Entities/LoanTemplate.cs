using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public class LoanTemplate: BaseEntity
    {
        public string Name { get; set; }
        public IList<Section> Sections { get; set; } = new List<Section>();
        public IList<Loan> Loans { get; set; } = new List<Loan>();
        public DateTime CreationDate { get; set; }
        public bool IsRemoved { get; set; }
    }
}
