using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Zafaran.WareHouse.Core.Entities.Aggregates.CommodityRequestCheckouts;

namespace Zafaran.Warehouse.Infrastructure.EntityConfigs
{
    public class CommodityRequestCheckoutConfig:IEntityTypeConfiguration<CommodityRequestCheckout>
    {
        public void Configure(EntityTypeBuilder<CommodityRequestCheckout> builder)
        {
            builder.HasMany(x => x.LineItems).WithOne();
            builder.Property(x => x.State).HasField("_state");
        }
    }
}