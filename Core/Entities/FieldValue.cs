namespace Core.Entities
{
    public class FieldValue: BaseEntity
    { 
        public string Value { get; set; }
        public int FieldId { get; set; }
        public Field Field { get; set; }
        public int LoanId { get; set; }
        public Loan Loan { get; set; }
    }
}
