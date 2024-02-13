using System.Linq;
using System.Threading.Tasks;

namespace Core.Interfaces.Infrastructure
{
    public interface IGenericRepository<T>
    {
        IQueryable<T> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> CreateAsync(T item);
        Task<T> UpdateAsync(T item);
    }
}
