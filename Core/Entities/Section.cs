using System.Collections.Generic;

namespace Core.Entities
{
    public class Section: BaseEntity
    { 
        public string Title { get; set; }
        public IList<Field> Fields { get; set; } = new List<Field>();
        public int LoanTemplateId { get; set; }
        public LoanTemplate LoanTemplate { get; set; }
    }
}
