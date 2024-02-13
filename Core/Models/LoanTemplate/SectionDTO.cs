using System.Collections.Generic;

namespace Core.Models.LoanTemplate
{
    public class SectionDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public IList<FieldDTO> Fields { get; set; }
    }
}
