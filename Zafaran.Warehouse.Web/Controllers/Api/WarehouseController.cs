using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Zafaran.Warehouse.Core.Contracts.Services;
using Zafaran.Warehouse.Core.Dtos.Warehouses;
using Zafaran.WareHouse.Core.Dtos;

namespace Zafaran.Warehouse.Web.Controllers.Api
{
    /// <summary>
    /// مدیریت انبار
    /// </summary>
    [Route("api/[controller]")]
    public class WarehouseController : Controller
    {
        private readonly IWarehouseService _warehouseService;

        public WarehouseController(IWarehouseService warehouseService)
        {
            _warehouseService = warehouseService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<WarehouseViewModel>>> Get(int id)
        {
            return Ok(await _warehouseService.GetById(id));
        }

        [HttpGet]
        public async Task<ActionResult<List<WarehouseViewModel>>> Get()
        {
            return Ok(await _warehouseService.GetAll());
        }

        [HttpPost]
        public async Task<ActionResult<Response>> Post([FromBody] WarehouseAddOrUpdateModel model)
        {
            return Ok(await _warehouseService.Add(model));
        }

        [HttpPut]
        public async Task<ActionResult<List<WarehouseViewModel>>> Put([FromBody] WarehouseAddOrUpdateModel model)
        {
            if (model.Id == 0) return BadRequest("id is missing");
            return Ok(await _warehouseService.Edit(model));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<WarehouseViewModel>>> Delete(int id)
        {
            return Ok(await _warehouseService.Delete(id));
        }
    }
}
