using Microsoft.EntityFrameworkCore;
using Management.Trip.Service.Infrastructure.Domain;

namespace Management.Trip.Service.Infrastructure.DataAccess
{
    public class TripDbContext : DbContext
    {
        public DbSet<Service.Domain.Trip> Trips { get; set; }

        public TripDbContext(DbContextOptions<TripDbContext> options)
                : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TripEntityTypeConfiguration).Assembly);
        }
    }
}
