using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Allwin_Planning.Core.Entities;

namespace Allwin_Planning.Infrastructure.Configurations
{
    public class DeliveryConfiguration : IEntityTypeConfiguration<Delivery>
    {
        public void Configure(EntityTypeBuilder<Delivery> builder)
        {
            builder.ToTable("Delivery");
            builder.HasKey(e => e.Gid);
            builder.Property(e => e.Shape).HasColumnType("geometry");
        }
    }
}
