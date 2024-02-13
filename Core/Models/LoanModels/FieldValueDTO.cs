namespace Core.Models.LoanModels
{
    public class FieldValueDTO
    {
        public int? Id { get; set; }
        public string Value { get; set; }
        public int? FieldId { get; set; }
        public int? LoanId { get; set; }
    }
}
