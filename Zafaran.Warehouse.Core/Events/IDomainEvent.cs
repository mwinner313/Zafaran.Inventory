using System;

namespace Zafaran.WareHouse.Core.Services.CommodityRequestFormServices
{
    public interface IDomainEvent
    {
        DateTime DateTimeEventOccurred { get; }
    }
}