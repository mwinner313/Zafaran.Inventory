using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Zafaran.Warehouse.Core.Contracts.Repositories
{
    public interface IRepository<T,Tkey> where T :class where Tkey :struct 
    {
        Task<T> GetByIdAsync(Tkey id);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        IQueryable<T> GetQueriable();
        EntityEntry<T> Entiry(T model);
        Task AddAsync(T model);
    }
}