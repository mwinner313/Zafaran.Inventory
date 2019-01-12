using System;
using System.Threading.Tasks;
using Zafaran.Warehouse.Core.Dtos.CommodityRequestCheckouts;
using Zafaran.WareHouse.Core.Contracts;
using Zafaran.WareHouse.Core.Entities.Aggregates.CommodityRequestCheckouts;

namespace Zafaran.Warehouse.Core.Repositories
{
    public interface ICommodityRequestCheckoutRepository
    {
        Task<CommodityRequestCheckout> GetById(Guid id);
        Task Create(CommodityRequestCheckout model);
        Task Update(CommodityRequestCheckout model);
        CommodityRequestCheckout GetByRequestFormId(Guid formId);
        Task<PagenatedList<CommodityRequestCheckoutViewModel>>GetList(CommodityRequestCheckoutQuery query);
    }
}