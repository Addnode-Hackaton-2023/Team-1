using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Allwin_Planning.Core.Entities;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Allwin_Planning.Infrastructure.Configurations
{
    public class PickupConfiguration : IEntityTypeConfiguration<Pickup>
    {
        public void Configure(EntityTypeBuilder<Pickup> builder)
        {
            builder.ToTable("Pickup");
            builder.HasKey(e => e.Gid);
            builder.Property(e => e.Shape).HasColumnType("geometry");
            builder.Property(e => e.Active).HasConversion(new BoolToZeroOneConverter<short>());
        }
    }
}
