using System.Linq;
using Zafaran.Warehouse.Core.Contracts.Repositories;
using Zafaran.Warehouse.Core.Repositories;
using Zafaran.WareHouse.Core.Entities.Aggregates.CommodityRequestCheckouts;
using Zafaran.WareHouse.Core.Entities.Aggregates.CommodityRequestForms;
using Zafaran.WareHouse.Core.Events.CommodityForms;

namespace Zafaran.Warehouse.Core.Events.Handlers
{
    public class WarehouseCommodityRequestFormChekoutHandler : IHandler<NewCommodityRequestFormAddedEvent>,
        IHandler<CommodityEditedFormEvent>
    {
        private readonly ICommodityRequestCheckoutRepository _repository;
        private readonly ICommodityRepository _commodityRepository;

        public WarehouseCommodityRequestFormChekoutHandler(ICommodityRequestCheckoutRepository repository, ICommodityRepository commodityRepository)
        {
            _repository = repository;
            _commodityRepository = commodityRepository;
        }

        public void Handle(NewCommodityRequestFormAddedEvent arg)
        {
            LoadRefrencedCommidities(arg.Form);
            var checkoutForm = CommodityRequestCheckout.Create(arg.Form);
            _repository.Create(checkoutForm).Wait();
        }

        private  void LoadRefrencedCommidities(CommodityRequestForm arg)
        {
          
            if (arg.LineItems.All(x => x.Commodity == null))
            {
                _commodityRepository.GetListByIds( arg.LineItems.Select(x => x.CommodityId).ToList()).ForEach(x =>
                {
                    foreach (var lineItem in arg.LineItems)
                    {
                        if (lineItem.CommodityId == x.Id)
                            lineItem.Commodity = x;
                    }
                });
            }
        }

        public void Handle(CommodityEditedFormEvent arg)
        {
            LoadRefrencedCommidities(arg.Form);
            var checkoutForm = _repository.GetByRequestFormId(arg.Form.Id);
            checkoutForm.UpdateItemsByForm(arg.Form);
            _repository.Update(checkoutForm).Wait();
        }
    }
}