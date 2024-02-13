namespace Core.CustomException
{
    public class CarBrandNotFoundException : NotFoundException
    {
        public CarBrandNotFoundException(int id) : base($"CarBrand with id = {id} doesn't exist")
        {

        }
    }
}
