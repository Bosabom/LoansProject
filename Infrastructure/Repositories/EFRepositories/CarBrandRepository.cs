using Core.Entities;
using Core.Interfaces.Infrastructure;
using Infrastructure.Data;
using Infrastructure.Repositories.Base;

namespace Infrastructure.Repositories.EFRepositories
{
    public class CarBrandRepository: BaseEfRepository<CarBrand>, ICarBrandRepository
    {
        public CarBrandRepository(AppDbContext appDbContext) : base(appDbContext) { }

        public CarBrand MarkAsRemoved(CarBrand carBrand)
        {
            carBrand.IsRemoved = true;
            return carBrand;
        }
    }
}
