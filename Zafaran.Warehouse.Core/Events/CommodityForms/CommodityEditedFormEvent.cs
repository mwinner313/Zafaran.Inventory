using System;
using Zafaran.WareHouse.Core.Entities.Aggregates.CommodityRequestForms;
using Zafaran.WareHouse.Core.Services.CommodityRequestFormServices;

namespace Zafaran.WareHouse.Core.Events.CommodityForms
{
    public class CommodityEditedFormEvent : IDomainEvent
    {
        public CommodityRequestForm Form { get; private set; }

        public CommodityEditedFormEvent(CommodityRequestForm form)
        {
            Form = form;
        }

        public DateTime DateTimeEventOccurred { get; } = DateTime.Now;
    }
}