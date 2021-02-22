using Management.Customer.Service.Infrastructure.Domain;
using Microsoft.EntityFrameworkCore;

namespace Management.Customer.Service.Infrastructure.DataAccess
{
    public class CustomerDbContext : DbContext
    {
        public DbSet<Service.Domain.Customer> Customers { get; set; }
        public DbSet<Service.Domain.CustomerTrip> CustomerTrips { get; set; }
        public DbSet<Service.Domain.Trip> Trips { get; set; }

        public CustomerDbContext(DbContextOptions<CustomerDbContext> options)
                : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CustomerEntityTypeConfiguration).Assembly);
        }
    }
}
