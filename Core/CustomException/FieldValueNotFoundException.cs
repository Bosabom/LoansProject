namespace Core.CustomException
{
    public class FieldValueNotFoundException : NotFoundException
    {
        public FieldValueNotFoundException(string message) : base(message) { }
    }
}
