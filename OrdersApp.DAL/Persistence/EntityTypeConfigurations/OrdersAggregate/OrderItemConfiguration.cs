using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrdersApp.Domain.Entities.OrdersAggregate;

namespace OrdersApp.DAL.Persistence.EntityTypeConfigurations.OrdersAggregate
{
    internal class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.HasKey(orderItem => orderItem.Id);
            builder.HasIndex(orderItem => orderItem.Id).IsUnique();

            builder.Property(orderItem => orderItem.Name).HasMaxLength(4000).IsRequired();
            builder.Property(orderItem => orderItem.Quantity).HasColumnType("decimal(18, 3)").IsRequired();
            builder.Property(orderItem => orderItem.Unit).HasMaxLength(4000).IsRequired();

            builder.Property(orderItem => orderItem.OrderId).IsRequired();
            builder.HasIndex(orderItem => orderItem.OrderId);

            builder.HasOne(order => order.Order)
                .WithMany(orderItem => orderItem.OrderItems)
                .HasForeignKey(orderItem => orderItem.OrderId)
                .HasPrincipalKey(order => order.Id);
        }
    }
}

