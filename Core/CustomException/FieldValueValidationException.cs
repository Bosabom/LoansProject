namespace Core.CustomException.FieldValueValidation
{
    public class FieldValueValidationException: BadRequest
    {
        public FieldValueValidationException(string message) : base(message) { }
    }
}
