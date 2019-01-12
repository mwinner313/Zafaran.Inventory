using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Zafaran.Warehouse.Core.Contracts.Repositories;
using Zafaran.Warehouse.Core.Dtos.CommodityRequestCheckouts;
using Zafaran.Warehouse.Core.Events;
using Zafaran.Warehouse.Core.Events.CommodityRequestCheckouts;
using Zafaran.Warehouse.Core.Events.Handlers;
using Zafaran.Warehouse.Core.Repositories;
using Zafaran.WareHouse.Core.Contracts;
using Zafaran.WareHouse.Core.Dtos;
using Zafaran.WareHouse.Core.Entities.Aggregates.CommodityRequestCheckouts;
using Zafaran.WareHouse.Core.Services.CommodityRequestFormServices;

namespace Zafaran.Warehouse.Core.Services.CommodityRequestCheckoutServices
{
    public class CommodityRequestCheckoutService : ICommodityRequestCheckoutService
    {
        private readonly ICommodityRequestCheckoutRepository _repository;
        private readonly ICommodityRepository _commodityRepository;
        private readonly IMapper _mapper;

        public CommodityRequestCheckoutService(ICommodityRequestCheckoutRepository repository,
            IMapper mapper, ICommodityRepository commodityRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _commodityRepository = commodityRepository;
        }

        public async Task<CommodityRequestCheckoutViewModel> GetById(Guid formId)
        {
            return _mapper.Map<CommodityRequestCheckoutViewModel>(await _repository.GetById(formId));
        }

        public async Task<Response> Edit(CommodityRequestCheckoutViewModel model)
        {
            var checkout = await _repository.GetById(model.Id);
            var updatedItems = _mapper.Map<List<CheckoutedLineItem>>(model.LineItems);
            var selectedCommodities =
                _commodityRepository.GetListByIds(updatedItems.Select(x => x.CommodityId).ToList());
            updatedItems.ForEach(x => { x.Commodity = selectedCommodities.First(c => c.Id == x.CommodityId); });
            checkout.UpdateItems(updatedItems);
            return Response.Success();
        }

        public async Task<PagenatedList<CommodityRequestCheckoutViewModel>> GetList(CommodityRequestCheckoutQuery query)
        {
            return await _repository.GetList(query);
        }
    }
}