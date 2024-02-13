namespace Core.CustomException
{
    public class LoanTemplateNotFoundException: NotFoundException
    {
        public LoanTemplateNotFoundException(int id) : base($"LoanTemplate with id = {id} doesn't exist")
        {

        }
    }
}
