using Core.Entities;
using Core.Models.CarBrand;

namespace Core.Extensions.CarBrands
{
    public static class CarBrandToResponse
    {
        public static CarBrandUpdate ToResponse(this CarBrand carBrand)
        {
            var response = new CarBrandUpdate
            {
                Id = carBrand.Id,
                Name = carBrand.Name
            };
            return response;
        }
    }
}
