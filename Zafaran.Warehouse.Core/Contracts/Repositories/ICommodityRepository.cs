using System.Collections.Generic;
using Zafaran.Warehouse.Core.Repositories;
using Zafaran.WareHouse.Core.Entities;

namespace Zafaran.Warehouse.Core.Contracts.Repositories
{
    public interface ICommodityRepository:IRepository<Commodity,int>
    {
        List<Commodity> GetListByIds(List<int> ids);
    }
}