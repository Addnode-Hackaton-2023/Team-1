using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Allwin_Planning.Core.Entities;

namespace Allwin_Planning.Infrastructure.Configurations
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
