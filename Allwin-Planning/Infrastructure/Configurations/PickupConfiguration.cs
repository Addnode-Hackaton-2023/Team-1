using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Allwin_Planning.Core.Entities;

namespace Allwin_Planning.Infrastructure.Configurations
{
    public class PickupConfiguration : IEntityTypeConfiguration<Pickup>
    {
        public void Configure(EntityTypeBuilder<Pickup> builder)
        {
            builder.ToTable("Pickup");
            builder.HasKey(e => e.Gid);
        }
    }
}
