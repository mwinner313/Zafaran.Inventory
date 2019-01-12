using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Zafaran.Warehouse.Core.Contracts.Repositories;
using Zafaran.Warehouse.Core.Events;
using Zafaran.WareHouse.Core.Contracts;
using Zafaran.WareHouse.Core.Dtos;
using Zafaran.WareHouse.Core.Dtos.CommodityRequestForms;
using Zafaran.WareHouse.Core.Entities.Aggregates.CommodityRequestForms;
using Zafaran.WareHouse.Core.Events.CommodityForms;

namespace Zafaran.WareHouse.Core.Services.CommodityRequestFormServices
{
    public class CommodityRequestFormService : ICommodityRequestFormService
    {
        private readonly ICommodityRequestFormRepository _commodityRequestFormRepository;
        private readonly IEventDispatcher _eventDispatcher;
        private readonly IMapper _mapper;

        public CommodityRequestFormService(ICommodityRequestFormRepository commodityRequestFormRepository,
            IMapper mapper, IEventDispatcher eventDispatcher)
        {
            _commodityRequestFormRepository = commodityRequestFormRepository;
            _mapper = mapper;
            _eventDispatcher = eventDispatcher;
        }

        public async Task<Response> CreateForm(int resturantId,
            IEnumerable<CommodityRequestFormLineItemViewModel> lineItems)
        {
            var req = new CommodityRequestForm(lineItems.Select(x => new CommodityRequestFormLineItem
            {
                Amount = x.Amount,
                CommodityId = x.CommodityId
            }).ToList(), resturantId);
            await _commodityRequestFormRepository.AddAsync(req);
            _eventDispatcher.Raise(new NewCommodityRequestFormAddedEvent(req));
            return Response.Success();
        }

        public async Task<CommodityRequestFormViewModel> Get(Guid formId)
        {
            var form = await _commodityRequestFormRepository.GetAsync(formId);
            return _mapper.Map<CommodityRequestFormViewModel>(form);
        }

        public async Task<Response> UpdateForm(Guid formId, IEnumerable<CommodityRequestFormLineItemViewModel> lineItems)
        {
            var form = await _commodityRequestFormRepository.GetAsync(formId);
            form.UpdateItems(_mapper.Map<List<CommodityRequestFormLineItem>>(lineItems));
            await _commodityRequestFormRepository.UpdateAsync(form);
            _eventDispatcher.Raise(new CommodityEditedFormEvent(form));
            return Response.Success();
        }

        public async Task<PagenatedList<CommodityRequestFormViewModel>> GetTodayListForResturant(int page, int size,
            int resturantId)
        {
            var (count, items) = await _commodityRequestFormRepository.GetTodayListAsync(resturantId, size, page);
            return new PagenatedList<CommodityRequestFormViewModel>
            {
                Items = _mapper.Map<List<CommodityRequestFormViewModel>>(items),
                Total = count
            };
        }
    }
}