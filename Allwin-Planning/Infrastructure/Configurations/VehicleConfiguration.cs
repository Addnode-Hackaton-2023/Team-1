using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Allwin_Planning.Core.Entities;

namespace Allwin_Planning.Infrastructure.Configurations
{
    public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.ToTable("Vehicle");
            builder.HasKey(e => e.Gid);
            builder.HasMany(e => e.Deliveries).WithOne().HasForeignKey(e => e.Gid).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(e => e.Pickups).WithOne().HasForeignKey(e => e.Gid).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
