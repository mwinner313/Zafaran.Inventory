using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Zafaran.WareHouse.Core.Entities.Aggregates.CommodityRequestCheckouts;

namespace Zafaran.Warehouse.Infrastructure.EntityConfigs
{
    public class CommodityRequestCheckoutLineItemConfig:IEntityTypeConfiguration<CheckoutedLineItem>
    {
        public void Configure(EntityTypeBuilder<CheckoutedLineItem> builder)
        {
            builder.HasOne(x => x.Commodity).WithMany().HasForeignKey(x=>x.CommodityId);
            builder.Ignore(x => x.State);
        }
    }
}