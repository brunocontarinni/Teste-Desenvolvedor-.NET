using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IBaseRepository<T>
    {
         Task<IEnumerable<T>> GetAllAsync();
         Task<T> GetByIdAsync(int id);
         Task<T> AddAsync(T entity);
         Task<bool> UpdateAsync(T entity);
         Task<bool> DeleteAsync(int id);
    }
}