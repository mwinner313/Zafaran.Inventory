using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Zafaran.WareHouse.Core.Services.CommodityRequestFormServices;

namespace Zafaran.Warehouse.Core.Events
{
    public class EventDispatcher : IEventDispatcher
    {
        private readonly List<Delegate> actions=new List<Delegate>();
        private readonly IServiceProvider _serviceProvider;

        public EventDispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void Raise<T>(T arg) where T : IDomainEvent
        {
            _serviceProvider.GetServices<IHandler<T>>().ToList().ForEach(x =>
            {
                x.Handle(arg);
            });
            foreach (var action in actions.OfType<Action<T>>() )
                action(arg);
        }

        public void Register<T>(Action<T> action) where T : IDomainEvent
        {
           actions.Add(action);
        }
    }
}