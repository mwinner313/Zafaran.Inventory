using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Zafaran.WareHouse.Core.Entities.Aggregates.CommodityRequestForms;

namespace Zafaran.WareHouse.Infrastructure.EntityConfigs
{
    public class CommodityRequestFormLineItemConfig:IEntityTypeConfiguration<CommodityRequestFormLineItem>
    {
        public void Configure(EntityTypeBuilder<CommodityRequestFormLineItem> builder)
        {
            builder.Ignore(x => x.State);
        }
    }
}