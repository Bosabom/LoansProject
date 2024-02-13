namespace Core.CustomException
{
    public class LoanNotFoundException : NotFoundException
    {
        public LoanNotFoundException(int id) : base($"Loan with id = {id} doesn't exist")
        {

        }
    }
}
