using System.Collections.Generic;
using System.Threading.Tasks;
using Zafaran.Warehouse.Core.Dtos.Warehouses;
using Zafaran.WareHouse.Core.Dtos;

namespace Zafaran.Warehouse.Core.Contracts.Services
{
    public interface IWarehouseService
    {
        Task<Response> Add(WarehouseAddOrUpdateModel model);
        Task<Response> Edit(WarehouseAddOrUpdateModel model);
        Task<Response> Delete (int id);
        Task<List<WarehouseViewModel>> GetAll ();
        Task<WarehouseViewModel> GetById(int id);
    }
}