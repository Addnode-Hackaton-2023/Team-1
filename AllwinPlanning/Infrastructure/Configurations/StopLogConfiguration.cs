using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using AllwinPlanning.Core.Entities;

namespace AllwinPlanning.Infrastructure.Configurations
{
    public class StopLogConfiguration : IEntityTypeConfiguration<StopLog>
    {
        public void Configure(EntityTypeBuilder<StopLog> builder)
        {
            builder.ToTable("StopLog");
            builder.HasKey(e => e.Gid);
        }
    }
}
