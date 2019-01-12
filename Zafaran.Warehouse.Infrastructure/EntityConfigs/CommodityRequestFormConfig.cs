using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Zafaran.WareHouse.Core.Entities.Aggregates.CommodityRequestForms;

namespace Zafaran.WareHouse.Infrastructure.EntityConfigs
{
    public class CommodityRequestFormConfig:IEntityTypeConfiguration<CommodityRequestForm>
    {
        public void Configure(EntityTypeBuilder<CommodityRequestForm> builder)
        {
            builder.HasMany(x=>x.LineItems).WithOne().HasForeignKey(x=>x.FormId).IsRequired();
            builder.Property(x => x.ResturantId).HasField("_resturantId");
            builder.Property(x => x.State).HasField("_state");
        }
    }
}