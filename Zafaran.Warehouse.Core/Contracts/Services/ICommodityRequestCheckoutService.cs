using System;
using System.Threading.Tasks;
using Zafaran.Warehouse.Core.Dtos.CommodityRequestCheckouts;
using Zafaran.WareHouse.Core.Dtos;

namespace Zafaran.WareHouse.Core.Contracts
{
    public interface ICommodityRequestCheckoutService
    {
        Task<CommodityRequestCheckoutViewModel> GetById(Guid formId);
        Task<Response> Edit(CommodityRequestCheckoutViewModel model);
        Task<PagenatedList<CommodityRequestCheckoutViewModel>> GetList(CommodityRequestCheckoutQuery query);
    }
}