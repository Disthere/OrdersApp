using MediatR;
using OrdersApp.DAL.Persistence;
using OrdersApp.Domain.Entities.OrdersAggregate;
using System.Threading;
using System.Threading.Tasks;

namespace OrdersApp.DAL.MediatRAccess.OrdersAggregate.OrderItems.Commands.CreateOrderItem
{
    public class CreateOrderItemCommandHandler : IRequestHandler<CreateOrderItemCommand, int>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public CreateOrderItemCommandHandler(IApplicationDbContext applicationDbContext) =>
            _applicationDbContext = applicationDbContext;


        public async Task<int> Handle(CreateOrderItemCommand request, CancellationToken cancellationToken)
        {
            var orderItem = new OrderItem()
            {
                Name = request.Name,
                Quantity = request.Quantity,
                Unit = request.Unit
            };

            await _applicationDbContext.OrderItems.AddAsync(orderItem, cancellationToken);
            await _applicationDbContext.SaveChangesAsync(cancellationToken);

            return orderItem.Id;
        }
    }
}
