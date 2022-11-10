using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using OrdersApp.Domain.Entities.OrdersAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

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
                .HasForeignKey(order => order.OrderId)
                .HasPrincipalKey(t => t.Id);
        }
    }
}

