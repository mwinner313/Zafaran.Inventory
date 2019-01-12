using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Zafaran.Warehouse.Core.Dtos.CommodityRequestCheckouts;
using Zafaran.Warehouse.Core.Events.Handlers;
using Zafaran.Warehouse.Core.Helpers;
using Zafaran.Warehouse.Core.Repositories;
using Zafaran.WareHouse.Core.Contracts;
using Zafaran.WareHouse.Core.Entities.Aggregates.CommodityRequestCheckouts;
using Zafaran.WareHouse.Core.Entities.Aggregates.CommodityRequestForms;
using Zafaran.WareHouse.Infrastructure;

namespace Zafaran.Warehouse.Infrastructure.Repositories
{
    public class CommodityRequestCheckoutRepository : BaseRepository, ICommodityRequestCheckoutRepository
    {
        private readonly IMapper _mapper;
        public async Task<CommodityRequestCheckout> GetById(Guid id)
        {
            return await  DbContext.CommodityRequestCheckouts.Include(x => x.LineItems)
                .Include(x => x.LineItems).ThenInclude(x=>x.Commodity).ThenInclude(x=>x.Unit)
                .FirstOrDefaultAsync(x => x.Id.ToString() == id.ToString());
        }

        public Task Create(CommodityRequestCheckout model)
        {
            DbContext.CommodityRequestCheckouts.Add(model);
            return DbContext.SaveChangesAsync();
        }

        public Task Update(CommodityRequestCheckout model)
        {
            foreach (var lineItem in model.LineItems)
            {
                switch (lineItem.State)
                {
                    case TrackingState.Added:
                        DbContext.Entry(lineItem).State = EntityState.Added;
                        break;
                    case TrackingState.Edited:
                        DbContext.Entry(lineItem).State = EntityState.Modified;
                        break;
                    case TrackingState.Deleted:
                        DbContext.Entry(lineItem).State = EntityState.Deleted;
                        break;
                }
            }

            DbContext.Update(model);
            return DbContext.SaveChangesAsync();
        }

        public CommodityRequestCheckout GetByRequestFormId(Guid formId)
        {
            return DbContext.CommodityRequestCheckouts.Include(x => x.LineItems)
                .Include(x => x.LineItems).ThenInclude(x=>x.Commodity)
                .FirstOrDefault(x => x.RequestForm.Id.ToString() == formId.ToString());
        }

        public async Task<PagenatedList<CommodityRequestCheckoutViewModel>> GetList(CommodityRequestCheckoutQuery query)
        {
            var dbquery = DbContext.CommodityRequestCheckouts.AsQueryable();
            if (query.StartDate.HasValue)
                dbquery = dbquery.Where(x => x.CreatedOn > query.StartDate);
            if (query.EndDate.HasValue)
                dbquery = dbquery.Where(x => x.CreatedOn < query.EndDate);
            if (query.ResturantId.HasValue)
                dbquery = dbquery.Where(x => x.RequestForm.ResturantId == query.ResturantId);
            
            return new PagenatedList<CommodityRequestCheckoutViewModel>
            {
                //to has error while retriving
                Items = dbquery.Pagenate(query).ProjectTo<CommodityRequestCheckoutViewModel>(_mapper.ConfigurationProvider).ToList(),
                Total = dbquery.Count()
            };
        }

        public CommodityRequestCheckoutRepository(AppDbContext dbContext, IMapper mapper) : base(dbContext)
        {
            _mapper = mapper;
        }
    }
}