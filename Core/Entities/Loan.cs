using Core.Enums;
using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public class Loan: BaseEntity
    {
        public IList<FieldValue> FieldValues { get; set; } = new List<FieldValue>();
        public LoanStatus Status { get; set; }
        public string LoanTemplateName { get; set; }
        public int LoanTemplateId { get; set; }
        public LoanTemplate Template { get; set; }
        public DateTime CreationDate { get; set; }
        public bool IsRemoved { get; set; }
    }
}