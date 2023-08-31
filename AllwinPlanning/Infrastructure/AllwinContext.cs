using AllwinPlanning.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace AllwinPlanning.Infrastructure
{
    public class AllwinContext : DbContext
    {
        public AllwinContext(DbContextOptions<AllwinContext> options) : base (options) { }

        public DbSet<Area> Areas { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }
        public DbSet<DeliveryDay> DeliveryDay { get; set; }
        public DbSet<Depot> Depots { get; set; }
        public DbSet<Pickup> Pickups { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<StopLog> StopLog { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder) => modelBuilder.ApplyAllConfigurations(typeof(AllwinContext));
    }
}
