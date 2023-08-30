using Allwin_Planning.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Allwin_Planning.Infrastructure
{
    public class AllwinContext : DbContext
    {
        public AllwinContext(DbContextOptions<AllwinContext> options) : base (options) { }

        public DbSet<Area> Areas { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }
        public DbSet<Depot> Depots { get; set; }
        public DbSet<Pickup> Pickups { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder) => modelBuilder.ApplyAllConfigurations(typeof(AllwinContext));
    }
}
