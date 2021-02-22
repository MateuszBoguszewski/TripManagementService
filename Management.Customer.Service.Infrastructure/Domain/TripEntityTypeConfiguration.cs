using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Management.Customer.Service.Infrastructure.Domain
{
    internal class TripEntityTypeConfiguration : IEntityTypeConfiguration<Service.Domain.Trip>
    {
        public void Configure(EntityTypeBuilder<Service.Domain.Trip> builder)
        {
            builder.ToTable("Trip");
            builder.HasKey(k => k.Id);

            builder.Property(x => x.Id).IsRequired().HasMaxLength(64);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property<DateTime>("StartDate").IsRequired();
            builder.Property<DateTime>("EndDate").IsRequired();
            builder.Property(x => x.IsCanceled).IsRequired();
        }
    }
}
