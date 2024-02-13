using Core.Entities;
using Core.Models.LoanModels;
using System.Collections.Generic;

namespace Core.Models.LoanTemplate
{
    public class SectionFullData
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<FieldFullDataDTO> Fields { get; set; } = new List<FieldFullDataDTO>();
    }
}
