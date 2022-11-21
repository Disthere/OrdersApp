using Microsoft.EntityFrameworkCore;
using OrdersApp.Domain.Entities.OrdersAggregate;
using System.Threading;
using System.Threading.Tasks;

namespace OrdersApp.DAL.Persistence
{
    public interface IApplicationDbContext
    {
        DbSet<Provider> Providers { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<OrderItem> OrderItems { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
