using AllwinPlanning.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AllwinPlanning.Infrastructure.Configurations
{
    public class DeliveryDayConfiguration : IEntityTypeConfiguration<DeliveryDay>
    {
        public void Configure(EntityTypeBuilder<DeliveryDay> builder)
        {
            builder.ToTable("DeliveryDay");
            builder.HasKey(e => e.Gid);
        }
    }
}
