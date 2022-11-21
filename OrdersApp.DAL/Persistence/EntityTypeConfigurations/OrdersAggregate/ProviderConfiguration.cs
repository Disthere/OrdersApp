using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrdersApp.Domain.Entities.OrdersAggregate;

namespace OrdersApp.DAL.Persistence.EntityTypeConfigurations.OrdersAggregate
{
    internal class ProviderConfiguration : IEntityTypeConfiguration<Provider>
    {
        public void Configure(EntityTypeBuilder<Provider> builder)
        {
            builder.HasKey(provider => provider.Id);
            builder.HasIndex(provider => provider.Id).IsUnique();

            builder.Property(provider => provider.Name).HasMaxLength(4000).IsRequired();

            builder.HasIndex(provider => provider.Name);
        }
    }
}

