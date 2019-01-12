using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Zafaran.Warehouse.Core.Events;
using Zafaran.Warehouse.Core.Events.Handlers;
using Zafaran.WareHouse.Core.Events.CommodityForms;

namespace Zafaran.WareHouse.Web.Infrastructure
{
    public static class ServiceCollectionExtensions
    {

        public static void RegisterEventHandlers(this IServiceCollection services)
        {
            services
                .AddScoped<IHandler<NewCommodityRequestFormAddedEvent>, WarehouseCommodityRequestFormChekoutHandler>();
            services
                .AddScoped<IHandler<CommodityEditedFormEvent>, WarehouseCommodityRequestFormChekoutHandler>();
        }

    }
}
