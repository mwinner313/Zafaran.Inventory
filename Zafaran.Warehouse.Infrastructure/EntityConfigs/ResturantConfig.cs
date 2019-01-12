using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Zafaran.WareHouse.Core.Entities;

namespace Zafaran.Warehouse.Infrastructure.EntityConfigs
{
    public class ResturantConfig:IEntityTypeConfiguration<Resturant>
    {
        public void Configure(EntityTypeBuilder<Resturant> builder)
        {
            builder.HasData(new
                Resturant
                {
                    Id = 1,
                    Title = "شعبه بلوار امین"
                });
            builder.HasData(new
                Resturant
                {
                    Id = 2,
                    Title = "شعبه امام"
                });
        }
    }
}