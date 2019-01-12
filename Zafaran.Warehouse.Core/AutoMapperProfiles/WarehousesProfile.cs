using AutoMapper;
using Zafaran.Warehouse.Core.Dtos.Warehouses;

namespace Zafaran.Warehouse.Core.AutoMapperProfiles
{
    public class WarehousesProfile:Profile
    {
        public WarehousesProfile()
        {
            CreateMap<WareHouse.Core.Entities.Warehouse, WarehouseViewModel>();
            CreateMap<WarehouseAddOrUpdateModel,WareHouse.Core.Entities.Warehouse>();
        }
    }
}