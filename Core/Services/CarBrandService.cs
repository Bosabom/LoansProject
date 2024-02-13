using Core.CustomException;
using Core.Entities;
using Core.Extensions.CarBrands;
using Core.Interfaces.Core;
using Core.Interfaces.Infrastructure;
using Core.Models.CarBrand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Services
{
    public class CarBrandService : ICarBrandService
    {
        private readonly IRepositoryProvider _repositoryProvider;
        public CarBrandService(IRepositoryProvider repositoryProvider)
        {
            _repositoryProvider = repositoryProvider;
        }
        public async Task<CarBrand> CreateAsync(CarBrandCreate createDTO)
        {
            var entity = new CarBrand
            {
                CreationDate = DateTime.Now,
                Name = createDTO.Name
            };
            await _repositoryProvider.CarBrands.CreateAsync(entity);
            await _repositoryProvider.SaveAsync();
            return entity;
        }

        public IList<CarBrandSummaryDTO> GetAllAsync()
        {
            return _repositoryProvider.CarBrands.GetAllAsync()
                .Where(x=>x.IsRemoved == false)
                .Select(x => new CarBrandSummaryDTO 
                { 
                    Id = x.Id,
                    Name = x.Name })
                .ToList();
        }

        public async Task<CarBrandResponse> GetByIdAsync(int id)
        {
            CarBrand entity = await _repositoryProvider.CarBrands.GetByIdAsync(id);
            if (entity is null)
            {
                throw new CarBrandNotFoundException(id);
            }
            return entity.ToDTO();
        }

        public async Task<CarBrandResponse> MarkAsRemoved(int id)
        {
            CarBrand entity = await _repositoryProvider.CarBrands.GetByIdAsync(id);
            if (entity is null)
            {
                throw new CarBrandNotFoundException(id);
            }
            _repositoryProvider.CarBrands.MarkAsRemoved(entity);
            await _repositoryProvider.SaveAsync();
            return entity.ToDTO();
        }

        public async Task<CarBrandUpdate> UpdateAsync(CarBrandUpdate updateDTO)
        {
            CarBrand entity = await _repositoryProvider.CarBrands.GetByIdAsync(updateDTO.Id);
            if (entity is null)
            {
                throw new CarBrandNotFoundException(updateDTO.Id);
            }
            entity.Name = updateDTO.Name;
            await _repositoryProvider.SaveAsync();
            return entity.ToResponse();
        }
    }
}
