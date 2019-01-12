using AutoMapper;
using Zafaran.WareHouse.Core.Dtos.CommodityRequestForms;
using Zafaran.WareHouse.Core.Entities.Aggregates.CommodityRequestForms;

namespace Zafaran.Warehouse.Core.AutoMapperProfiles
{
    public class CommodityRequestFormProfile:Profile
    {
        public CommodityRequestFormProfile()
        {
            CreateMap<CommodityRequestForm,CommodityRequestFormViewModel>();
            CreateMap<CommodityRequestFormViewModel,CommodityRequestForm>();
            CreateMap<CommodityRequestFormLineItem,CommodityRequestFormLineItemViewModel>();
            CreateMap<CommodityRequestFormLineItemViewModel,CommodityRequestFormLineItem>();
        }
    }
}