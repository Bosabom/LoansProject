using Core.Entities;
using Core.Enums;
using System.Collections.Generic;

namespace Core.Models.LoanModels
{
    public class FieldFullDataDTO
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string Title { get; set; }
        public string Value { get; set; }
        public int FieldValueId { get; set; }
        public int SectionId { get; set; }
        public FieldType Type { get; set; }
        public IList<Validation> Validation { get; set; } = new List<Validation>();
        public string OptionsUrl { get; set; }
        public IList<Option> Options { get; set; } = new List<Option>();
        public Calculated Calculated { get; set; }
        public Readonly Readonly { get; set; }
    }
}
