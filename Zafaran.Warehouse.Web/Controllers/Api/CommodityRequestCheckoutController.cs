using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Zafaran.Warehouse.Core.Dtos.CommodityRequestCheckouts;
using Zafaran.WareHouse.Core.Contracts;
using Zafaran.WareHouse.Core.Dtos;
using Zafaran.WareHouse.Web.Infrastructure;

namespace Zafaran.Warehouse.Web.Controllers.Api
{
    [Route("api/[controller]")]
    public class CommodityRequestCheckoutController : BaseController
    {
        private readonly ICommodityRequestCheckoutService _commodityRequestCheckoutService;

        public CommodityRequestCheckoutController(ICommodityRequestCheckoutService commodityRequestCheckoutService)
        {
            _commodityRequestCheckoutService = commodityRequestCheckoutService;
        }
        [HttpGet]
        public async Task<ActionResult<PagenatedList<CommodityRequestCheckoutViewModel>>> GetList([FromQuery]CommodityRequestCheckoutQuery query)
        {
            return Ok(await _commodityRequestCheckoutService.GetList(query));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CommodityRequestCheckoutViewModel>> Get(Guid id)
        {
            return Ok(await _commodityRequestCheckoutService.GetById(id));
        }
        [HttpPut]
        public async Task<ActionResult<Response>> Put(CommodityRequestCheckoutViewModel model)
        {
            return Ok(await _commodityRequestCheckoutService.Edit(model));
        }
    }
}
