using Core.Enums;
using Core.Extensions.LoanTemplateJsons;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class Field: BaseEntity
    {
        public string Key { get; set; }
        public string Title { get; set; }
        public FieldType Type { get; set; }
        public IList<FieldValue> FieldValues { get; set; } = new List<FieldValue>();
        public string OptionsUrl { get; set; }
        public int SectionId { get; set; }
        public Section Section { get; set; }
        public string _Validation { get; set; }

        [NotMapped]
        public IList<Validation> Validation 
        {
            get => _Validation.GetDeserializeObject<List<Validation>>();
            set {_Validation = JsonConvert.SerializeObject(value);}
        }

        public string _Readonly { get; set; }
        [NotMapped]
        public Readonly Readonly 
        {
            get => _Readonly.GetDeserializeObject<Readonly>();
            set { _Readonly = JsonConvert.SerializeObject(value); }
        }

        public string _Calculated { get; set; }
        [NotMapped]
        public Calculated Calculated
        {
            get => _Calculated.GetDeserializeObject<Calculated>();
            set { _Calculated = JsonConvert.SerializeObject(value); }
        }

        public string _Options { get; set; }
        [NotMapped]
        public IList<Option> Options
        {
            get => _Options.GetDeserializeObject<List<Option>>();
            set { _Options = JsonConvert.SerializeObject(value); }
        } 
    }
}
