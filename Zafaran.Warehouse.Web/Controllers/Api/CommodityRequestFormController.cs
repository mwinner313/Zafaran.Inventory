using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Zafaran.WareHouse.Core.Contracts;
using Zafaran.WareHouse.Core.Dtos;
using Zafaran.WareHouse.Core.Dtos.CommodityRequestForms;

namespace Zafaran.Warehouse.Web.Controllers.Api
{
    [Route("api/[controller]")]
    public class CommodityRequestFormController : Controller
    {
        private readonly ICommodityRequestFormService _formService;

        public CommodityRequestFormController(ICommodityRequestFormService formService)
        {
            _formService = formService;
        }
        /// <summary>
        /// دریافت فرم درخواست ثبت شده
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Response>> Get(Guid id)
        {
            return Ok(await _formService.Get(id));
        }

        /// <summary>
        /// لیست تمامی فرم درخواست های امروز
        /// </summary>
        /// <param name="resturantId">شناسه رستوران</param>
        /// <returns></returns>
        [HttpGet("GetTodayListRequests")]
        public async Task<ActionResult<PagenatedList<CommodityRequestFormViewModel>>> GetTodayListRequests(
            [FromQuery] CommodityRequestFormQuery query)
        {
            return Ok(await _formService.GetTodayListForResturant(query.Page, query.Size, query.RestaurantId));
        }
        /// <summary>
        /// ایجاد فرم درخواست
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Response>> Post([FromBody] CommodityRequestFormViewModel model)
        {
            return Ok(await _formService.CreateForm(model.ResturantId, model.LineItems));
        }
        /// <summary>
        /// ویرایش فرم درخواست
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult<Response>> Put([FromBody] CommodityRequestFormViewModel model)
        {
            return Ok(await _formService.UpdateForm(model.Id, model.LineItems));
        }
    }
}
