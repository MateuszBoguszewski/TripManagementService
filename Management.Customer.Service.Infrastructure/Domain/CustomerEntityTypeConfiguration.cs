using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Management.Customer.Service.Infrastructure.Domain
{
    internal class CustomerEntityTypeConfiguration : IEntityTypeConfiguration<Service.Domain.Customer>
    {
        public void Configure(EntityTypeBuilder<Service.Domain.Customer> builder)
        {
            builder.ToTable("Customer");
            builder.HasKey(k => k.Id);

            builder.Property(x => x.Id).IsRequired().HasMaxLength(64);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Password).IsRequired();
        }
    }
}
