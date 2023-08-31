using AllwinPlanning.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AllwinPlanning.Infrastructure.Configurations
{
	public class PickupConfiguration : IEntityTypeConfiguration<Pickup>
	{
		public void Configure(EntityTypeBuilder<Pickup> builder)
		{
			builder.ToTable("Pickup");
			builder.HasKey(e => e.Gid);
			builder.Property(e => e.Shape).HasColumnType("geometry");
			builder.Property(e => e.PickupType).HasConversion<int>();
			builder.Property(e => e.Active).HasConversion(new BoolToZeroOneConverter<short>());
		}
	}
}
