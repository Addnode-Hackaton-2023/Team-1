using Allwin_Planning.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Allwin_Planning.Infrastructure.Configurations
{
	public class DeliveryConfiguration : IEntityTypeConfiguration<Delivery>
	{
		public void Configure(EntityTypeBuilder<Delivery> builder)
		{
			builder.ToTable("Delivery");
			builder.HasKey(e => e.Gid);
			builder.Property(e => e.Shape).HasColumnType("geometry");
			builder.HasMany(e => e.DeliveryDays).WithOne().HasForeignKey(e => e.Gid).OnDelete(DeleteBehavior.Cascade);
		}
	}
}
