using AutoMapper;
using Zafaran.Warehouse.Core.Dtos.CommodityRequestCheckouts;
using Zafaran.WareHouse.Core.Dtos.CommodityRequestForms;
using Zafaran.WareHouse.Core.Entities.Aggregates.CommodityRequestCheckouts;
using Zafaran.WareHouse.Core.Entities.Aggregates.CommodityRequestForms;

namespace Zafaran.Warehouse.Core.AutoMapperProfiles
{
    public class CommodityRequestCheckoutProfile : Profile
    {
        public CommodityRequestCheckoutProfile()
        {
            CreateMap<CommodityRequestCheckout, CommodityRequestCheckoutViewModel>();
            CreateMap<CheckoutedLineItem, CheckoutedLineItemViewModel>();
            CreateMap<CommodityRequestCheckoutViewModel, CommodityRequestCheckout>();
            CreateMap<CheckoutedLineItemViewModel, CheckoutedLineItem>();
        }
    }
}