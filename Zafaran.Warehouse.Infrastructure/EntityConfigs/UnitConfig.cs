using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Zafaran.WareHouse.Core.Entities;

namespace Zafaran.Warehouse.Infrastructure.EntityConfigs
{
    public class UnitConfig:IEntityTypeConfiguration<Unit>
    {
        public void Configure(EntityTypeBuilder<Unit> builder)
        {
            builder.HasData(new Unit
            {
                Id = 2,
                Title = "کیلو"
            });
            builder.HasData(new Unit
            {
                Id = 1,
                Title = "مثقال"
            });
            builder.HasData(new Unit
            {
                Id = 4,
                Title = "گرم"
            });
            builder.HasData(new Unit
            {
                Id = 3,
                Title = "تن"
            });
        }
    }
}