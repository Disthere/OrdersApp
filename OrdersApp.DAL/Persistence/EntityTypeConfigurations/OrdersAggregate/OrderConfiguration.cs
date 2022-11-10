using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OrdersApp.Domain.Entities.OrdersAggregate;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                .HasForeignKey(provider => provider.Id)
                .HasPrincipalKey(t => t.Id);

            builder.HasKey(order => new { order.ProviderId, order.Number });
        }
    }
}

