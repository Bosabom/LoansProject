using Core.Entities;
using Core.Models.CarBrand;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces.Core
{
    public interface ICarBrandService
    {
        Task<CarBrand> CreateAsync(CarBrandCreate createDTO);
        Task<CarBrandResponse> GetByIdAsync(int id);
        Task<CarBrandUpdate> UpdateAsync(CarBrandUpdate updateDTO);
        IList<CarBrandSummaryDTO> GetAllAsync();
        Task<CarBrandResponse> MarkAsRemoved(int id);
    }
}
