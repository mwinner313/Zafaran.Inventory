using System;
using Zafaran.WareHouse.Core.Entities.Aggregates.CommodityRequestCheckouts;
using Zafaran.WareHouse.Core.Services.CommodityRequestFormServices;

namespace Zafaran.Warehouse.Core.Events.CommodityRequestCheckouts
{
    public class CommodityRequestCheckoutCreatedEvent:IDomainEvent
    {
        public CommodityRequestCheckoutCreatedEvent(CommodityRequestCheckout requestCheckout)
        {
            RequestCheckout = requestCheckout;
        }

        public DateTime DateTimeEventOccurred { get; }
        public CommodityRequestCheckout RequestCheckout { get;  }
    }
}