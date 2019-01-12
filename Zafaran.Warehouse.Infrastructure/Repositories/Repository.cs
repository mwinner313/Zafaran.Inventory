using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Zafaran.Warehouse.Core.Contracts.Repositories;
using Zafaran.Warehouse.Core.Repositories;
using Zafaran.WareHouse.Core.Entities;
using Zafaran.WareHouse.Core.Services.CommodityRequestFormServices;
using Zafaran.WareHouse.Infrastructure;

namespace Zafaran.Warehouse.Infrastructure.Repositories
{
    public class Repository<T, TKey> : IRepository<T, TKey> 
        where T : class, IHaveId<TKey> where TKey : struct
    {
        protected AppDbContext Db;

        public Repository(AppDbContext db)
        {
            Db = db;
        }

        public Task<T> GetByIdAsync(TKey id)
        {
            return  Db.Set<T>().FirstOrDefaultAsync(x =>x.Id.ToString()==id.ToString());
        }

        public Task AddAsync(T entity)
        {
            Db.Add(entity);
            return Db.SaveChangesAsync();
        }

        public Task UpdateAsync(T entity)
        {
            var exisiting = Db.Set<T>().First(x => x.Id.ToString()==entity.Id.ToString());
            Db.Entry(exisiting).CurrentValues.SetValues(entity);
            return Db.SaveChangesAsync();
        }

        public Task DeleteAsync(T entity)
        {
            if (entity is null) return Task.FromResult(1);
            if (Db.Entry(entity).State != EntityState.Detached)
            {
                Db.Remove(entity);
            }
            else
            {
                var existing = Db.Set<T>().First(x => x.Id.Equals(entity.Id));
                Db.Remove(existing);
            }
            return Db.SaveChangesAsync();
        }

        public IQueryable<T> GetQueriable()
        {
            return Db.Set<T>();
        }

        public EntityEntry<T> Entiry(T model)
        {
            return Db.Entry(model);
        }
    }
}