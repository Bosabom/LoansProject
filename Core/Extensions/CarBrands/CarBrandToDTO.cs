using Core.Entities;
using Core.Models.CarBrand;

namespace Core.Extensions.CarBrands
{
    public static class CarBrandToDTO
    {
        public static CarBrandResponse ToDTO(this CarBrand carBrand)
        {
            var model = new CarBrandResponse
            {
                Id = carBrand.Id,
                IsRemoved = carBrand.IsRemoved,
                Name = carBrand.Name
            };
            return model;
        }
    }
}
