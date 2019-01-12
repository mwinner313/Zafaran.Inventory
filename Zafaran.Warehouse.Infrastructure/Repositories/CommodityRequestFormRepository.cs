using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Zafaran.Warehouse.Core.Contracts.Repositories;
using Zafaran.WareHouse.Core.Entities.Aggregates.CommodityRequestForms;
using Zafaran.WareHouse.Core.Services.CommodityRequestFormServices;
using Zafaran.WareHouse.Infrastructure;

namespace Zafaran.Warehouse.Infrastructure.Repositories
{
    public class CommodityRequestFormRepository : BaseRepository, ICommodityRequestFormRepository
    {
        public async Task AddAsync(CommodityRequestForm model)
        {
            await DbContext.CommodityRequestForms.AddAsync(model);
            await DbContext.SaveChangesAsync();
        }

        public Task<CommodityRequestForm> GetAsync(Guid formId)
        {
            return DbContext.CommodityRequestForms.Include(x=>x.LineItems).FirstOrDefaultAsync(x => x.Id == formId);
        }

        public Task UpdateAsync(CommodityRequestForm form)
        {
            foreach (var item in form.LineItems)
            {
                switch (item.State)
                {
                    case TrackingState.Added:
                        DbContext.Entry(item).State = EntityState.Added;
                        break;
                    case TrackingState.Edited:
                        DbContext.Entry(item).State = EntityState.Modified;
                        break;
                    case TrackingState.Deleted:
                        DbContext.Entry(item).State = EntityState.Deleted;
                        break;
                }
            }

            DbContext.Entry(form).State = EntityState.Modified;
            return DbContext.SaveChangesAsync();
        }

        public async Task<(int count, List<CommodityRequestForm> items)> GetTodayListAsync(int resturantId, int size,
            int page)
        {
            var query = DbContext.CommodityRequestForms
                .Where(x => x.ResturantId == resturantId && x.CreatedOn.Date == DateTime.Now.Date);
            return (await query.CountAsync(), query.Skip(page * size).Take(size).ToList());
        }

        public CommodityRequestFormRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}