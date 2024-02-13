using Core.Entities.Base.Interfaces;
using Core.Interfaces.Infrastructure;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Base
{
    public abstract class BaseEfRepository<T> : IGenericRepository<T> where T : class, IBaseEntity
    {
        protected readonly AppDbContext _appDbContext;
        public BaseEfRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        // TODO: Add Specification pattern
        public IQueryable<T> GetAllAsync()
        {
            return _appDbContext.Set<T>();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _appDbContext.Set<T>().FindAsync(id);
        }
        public async Task<T> CreateAsync(T item)
        {
            await _appDbContext.Set<T>().AddAsync(item);
            return item;
        }

        public async Task<T> UpdateAsync(T modifiedItem)
        {
            _appDbContext.Entry(modifiedItem).State = EntityState.Modified;
            T item = await GetByIdAsync(modifiedItem.Id);
            return item;
        }
    }
}
