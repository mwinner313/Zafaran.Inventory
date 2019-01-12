using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Zafaran.WareHouse.Core.Entities;

namespace Zafaran.WareHouse.Infrastructure.EntityConfigs
{
    public class CommodityConfig : IEntityTypeConfiguration<Commodity>
    {
        public void Configure(EntityTypeBuilder<Commodity> builder)
        {
            builder.HasOne(x => x.Unit).WithMany().HasForeignKey(x => x.UnitId).IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasData(new Commodity
            {
                Id = 1,
                Code = 123312312.ToString(),
                Title = "گوشت قرمز گوسفندی",
                UnitId = 1
            });
            builder.HasData(new Commodity
            {
                Id = 2,
                Code = 123312312.ToString(),
                Title = "برنج",
                UnitId = 4
            });
            builder.HasData(new Commodity
            {
                Id = 3,
                Code = 123312312.ToString(),
                Title = "رب گوجه",
                UnitId = 1
            });
        }
    }
}