using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Zafaran.Warehouse.Core.Contracts.Repositories;
using Zafaran.Warehouse.Core.Repositories;
using Zafaran.WareHouse.Core.Entities;
using Zafaran.WareHouse.Core.Services.CommodityRequestFormServices;
using Zafaran.WareHouse.Infrastructure;

namespace Zafaran.Warehouse.Infrastructure.Repositories
{
    public class CommodityRepostory:Repository<Commodity,int>,ICommodityRepository
    {
        public CommodityRepostory(AppDbContext db) : base(db)
        {
        }

        public List<Commodity> GetListByIds(List<int> ids)
        {
            return Db.Commodities.Where(x => ids.Contains(x.Id)).ToList();
        }
    }
}