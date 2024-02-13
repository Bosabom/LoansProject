using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces.Core;
using Core.Models.CarBrand;
using LoansApi.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace LoansApi.Controllers
{
    public class CarBrandController : BaseApiController
    {
        private readonly ICarBrandService _carBrandService;
        public CarBrandController(ICarBrandService carBrandService)
        {
            _carBrandService = carBrandService;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] CarBrandCreate createDTO)
        {
            CarBrand carBrand = await _carBrandService.CreateAsync(createDTO);
            return Ok(carBrand);
        }
      
        [HttpGet("car-brands")]
        public IActionResult GetAllAsync()
        {
            IList<CarBrandSummaryDTO> summaryDTOs = _carBrandService.GetAllAsync();
            return Ok(summaryDTOs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            CarBrandResponse response = await _carBrandService.GetByIdAsync(id);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            CarBrandResponse response = await _carBrandService.MarkAsRemoved(id);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] CarBrandUpdate updateDTO)
        {
            CarBrandUpdate dTO = await _carBrandService.UpdateAsync(updateDTO);
            return Ok(dTO);
        }

    }
}
