using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices.Marshalling;
using ASP_NET_Project.Data.Models;

namespace ASP_NET_Project.Data
{
    public class MineralApplicationDbContext : DbContext
    {
        public MineralApplicationDbContext(DbContextOptions<MineralApplicationDbContext> dbContextOptions)
            : base(dbContextOptions)
        {
                
        }

        public virtual DbSet<Mineral> Minerals { get; set; } = null!;
        public virtual DbSet<Location> Locations { get; set; } = null!;
        public virtual DbSet<Museum> Museums { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MineralApplicationDbContext).Assembly);
        }
    }
}
