using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Zafaran.WareHouse.Core.Entities.Aggregates.CommodityRequestForms;

namespace Zafaran.Warehouse.Core.Contracts.Repositories
{
    public interface ICommodityRequestFormRepository
    {
        Task AddAsync(CommodityRequestForm model);
        Task<CommodityRequestForm> GetAsync(Guid formId);
        Task UpdateAsync(CommodityRequestForm form);
        Task<(int count,List<CommodityRequestForm> items)> GetTodayListAsync(int resturantId, int size, int page);
    }
}