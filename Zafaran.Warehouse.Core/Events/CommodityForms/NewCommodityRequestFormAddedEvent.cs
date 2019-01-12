using System;
using Zafaran.WareHouse.Core.Entities.Aggregates.CommodityRequestForms;
using Zafaran.WareHouse.Core.Services.CommodityRequestFormServices;

namespace Zafaran.WareHouse.Core.Events.CommodityForms
{
    public class NewCommodityRequestFormAddedEvent:IDomainEvent
    {
        public DateTime DateTimeEventOccurred { get; } = DateTime.Now;
        public CommodityRequestForm Form { get; }
        public NewCommodityRequestFormAddedEvent(CommodityRequestForm req)
        {
            Form = req;
        }
    }
}