using System;
using Zafaran.WareHouse.Core.Services.CommodityRequestFormServices;

namespace Zafaran.Warehouse.Core.Events
{
    public interface IEventDispatcher
    {
        void Raise<T>(T arg) where T : IDomainEvent;
        void Register<T>(Action<T> action) where T : IDomainEvent;
    }
}