using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Zafaran.Warehouse.Infrastructure.EntityConfigs;
using Zafaran.WareHouse.Core.Entities;
using Zafaran.WareHouse.Core.Entities.Aggregates.CommodityRequestCheckouts;
using Zafaran.WareHouse.Core.Entities.Aggregates.CommodityRequestForms;
using Zafaran.WareHouse.Core.Entities.Aggregates.InventoryEntryForms;
using Zafaran.WareHouse.Infrastructure.EntityConfigs;
using Zafaran.WareHouse.Infrastructure.Helpers;

namespace Zafaran.WareHouse.Infrastructure
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions opts) : base(opts)
        {
        }
        public DbSet<Unit> Units { get; set; }
        public DbSet<Resturant> Resturants { get; set; }
        public DbSet<Commodity> Commodities { get; set; }
        public DbSet<Core.Entities.Warehouse> WareHouses { get; set; }
        public DbSet<CommidityWarehouseInventory> CommidityWarehouseInventories { get; set; }
        public DbSet<CommodityRequestForm> CommodityRequestForms { get; set; }
        public DbSet<CommodityRequestCheckout> CommodityRequestCheckouts { get; set; }
        public DbSet<EntryForm> EntryForms { get; set; }
     

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.AddEntityConfigurationsFromAssembly(GetType().Assembly);
            base.OnModelCreating(builder);
        }
    }
}