using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using AllwinPlanning.Core.Entities;

namespace AllwinPlanning.Infrastructure.Configurations
{
    public class DepotConfiguration : IEntityTypeConfiguration<Depot>
    {
        public void Configure(EntityTypeBuilder<Depot> builder)
        {
            builder.ToTable("Depot");
            builder.HasKey(e => e.Gid);
            builder.Property(e => e.Shape).HasColumnType("geometry");
        }
    }
}
