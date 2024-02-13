using Core.Entities;
using Core.Enums;
using System.Collections.Generic;

namespace Core.Models.LoanTemplate
{
    public class FieldDTO
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string Title { get; set; }
        public FieldType Type { get; set; }
        public IList<ValidationDTO> Validation { get; set; } = new List<ValidationDTO>();
        public string OptionsUrl { get; set; }
        public IList<Option> Options { get; set; }
        public Calculated Calculated { get; set; }
        public Readonly Readonly { get; set; }
    }
}
