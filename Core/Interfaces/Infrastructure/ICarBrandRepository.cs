using Core.Entities;

namespace Core.Interfaces.Infrastructure
{
    public interface ICarBrandRepository: IGenericRepository<CarBrand>
    {
        CarBrand MarkAsRemoved(CarBrand carBrand);
    }
}
