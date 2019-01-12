using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Zafaran.WareHouse.Core.Dtos;
using Zafaran.WareHouse.Core.Dtos.CommodityRequestForms;

namespace Zafaran.WareHouse.Core.Contracts
{
    public interface ICommodityRequestFormService
    {
        Task<Response> CreateForm(int resturantId, IEnumerable<CommodityRequestFormLineItemViewModel> lineItems);
        Task<CommodityRequestFormViewModel> Get(Guid formId);
        Task<Response> UpdateForm(Guid formId,
            IEnumerable<CommodityRequestFormLineItemViewModel> lineItems);
        Task<PagenatedList<CommodityRequestFormViewModel>>
            GetTodayListForResturant(int page, int size, int resturantId);
    }
}