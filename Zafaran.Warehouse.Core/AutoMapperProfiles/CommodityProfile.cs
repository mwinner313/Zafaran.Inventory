using System.Linq;
using System.Reflection;
using AutoMapper;
using Zafaran.Warehouse.Core.Dtos.Commodities;
using Zafaran.WareHouse.Core.Entities;

namespace Zafaran.Warehouse.Core.AutoMapperProfiles
{
    public class CommodityProfile:Profile
    {
        public CommodityProfile()
        {
            CreateMap<Commodity, CommodityViewModel>();
            CreateMap<CommodityAddOrUpdateModel,Commodity>();
        }
    }
}