using BlazorTrails.Api.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlazorTrails.Api.Persistence
{
    public class AppDbContext : DbContext
    {
        public DbSet<Trail> Trails => Set<Trail>();
        public DbSet<RouteInstruction> RouteInstructions => Set<RouteInstruction>();

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new TrailConfig());
            modelBuilder.ApplyConfiguration(new RouteInstructionConfig());
        }
    }
}
