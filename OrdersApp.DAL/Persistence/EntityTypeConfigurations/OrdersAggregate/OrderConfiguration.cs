using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrdersApp.Domain.Entities.OrdersAggregate;

namespace OrdersApp.DAL.Persistence.EntityTypeConfigurations.OrdersAggregate
{
    internal class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(order => order.Id);
            builder.HasIndex(order => order.Id).IsUnique();

            builder.Property(order => order.Number).HasMaxLength(4000).IsRequired();
            builder.Property(order => order.Date).HasColumnType("datetime2(7)").IsRequired();

            builder.Property(order => order.ProviderId).IsRequired();
            builder.HasIndex(order => order.ProviderId);

            builder.HasOne(provider => provider.Provider)
                .WithMany(order => order.Orders)
                .HasForeignKey(provider => provider.ProviderId)
                .HasPrincipalKey(provider => provider.Id);

            //Включить при работе с SQL Server
            //builder.HasKey(order => new { order.ProviderId, order.Number });
        }
    }
}

