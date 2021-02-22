using Management.Customer.Service.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Management.Customer.Service.Infrastructure.Domain
{
    internal class CustomerTripEntityTypeConfiguration : IEntityTypeConfiguration<Service.Domain.CustomerTrip>
    {
        public void Configure(EntityTypeBuilder<CustomerTrip> builder)
        {
            builder.ToTable("CustomerTrip");
            builder.HasKey(k => new { k.CustomerId, k.TripId });

            builder.HasOne(ct => ct.Customer)
                .WithMany()
                .HasForeignKey(ct => ct.CustomerId);

            builder.HasOne(ct => ct.Trip)
                .WithMany()
                .HasForeignKey(ct => ct.TripId);
        }
    }
}
