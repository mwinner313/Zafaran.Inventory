using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Zafaran.Warehouse.Core.Contracts.Repositories;
using Zafaran.Warehouse.Core.Dtos;
using Zafaran.Warehouse.Core.Dtos.Commodities;
using Zafaran.Warehouse.Core.Helpers;
using Zafaran.Warehouse.Core.Repositories;
using Zafaran.WareHouse.Core.Dtos;
using Zafaran.WareHouse.Core.Entities;
using Zafaran.WareHouse.Web.Infrastructure;

namespace Zafaran.Warehouse.Web.Controllers.Api
{
    [Route("api/[controller]")]
    public class CommodityController : BaseController
    {
        private readonly ICommodityRepository _commodityRepository;
        private readonly IMapper _mapper;

        public CommodityController(ICommodityRepository commodityRepository, IMapper mapper)
        {
            _commodityRepository = commodityRepository;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CommodityViewModel>> Get(int id)
        {
            return Ok(_mapper.Map<CommodityViewModel>(await _commodityRepository.GetByIdAsync(id)));
        }

        [HttpGet]
        public async Task<ActionResult<List<CommodityViewModel>>> Get([FromQuery] CommodityQuery query)
        {
            var dbQuery = _commodityRepository.GetQueriable();
            if (!string.IsNullOrEmpty(query.SearchTerm))
                dbQuery = dbQuery.Where(x => x.Title.Contains(query.SearchTerm) || x.Code.Contains(query.SearchTerm));
            return Ok(dbQuery.Pagenate(query).ProjectTo<CommodityViewModel>(_mapper.ConfigurationProvider).ToList());
        }

        [HttpPost]
        public async Task<ActionResult<List<CommodityViewModel>>> Post([FromBody] CommodityAddOrUpdateModel model)
        {
            if (!ModelState.IsValid)
                return BadRequestWithModelStateErrors();
            var entity = _mapper.Map<Commodity>(model);
            await _commodityRepository.AddAsync(entity);
            _commodityRepository.Entiry(entity).Reference(x => x.Unit).Load();
            return Ok(_mapper.Map<CommodityViewModel>(entity));
        }


        [HttpPut]
        public async Task<ActionResult<List<CommodityViewModel>>> Put([FromBody] CommodityAddOrUpdateModel model)
        {
            if (!ModelState.IsValid)
                return BadRequestWithModelStateErrors();
            var entity = _mapper.Map<Commodity>(model);
            await _commodityRepository.UpdateAsync(entity);
            return Ok(_mapper.Map<CommodityViewModel>(entity));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Response>> Delete(int id)
        {
            var entity = await _commodityRepository.GetByIdAsync(id);
            if (entity is null) return Ok();
            await _commodityRepository.DeleteAsync(entity);
            return Ok(WareHouse.Core.Dtos.Response.Success());
        }
    }
}
