using MediatR;
using OrdersApp.DAL.MediatRAccess.OrdersAggregate.Orders.Commands.CreateOrder;
using OrdersApp.DAL.Persistence;
using OrdersApp.Domain.Entities.OrdersAggregate;
using System.Threading;
using System.Threading.Tasks;

namespace OrdersApp.DAL.MediatRAccess.OrdersAggregate.OrderItems.Commands.CreateOrderItem
{
    public class CreateOrderItemCommandHandler : IRequestHandler<CreateOrderItemCommand, CreateOrderItemVm>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public CreateOrderItemCommandHandler(IApplicationDbContext applicationDbContext) =>
            _applicationDbContext = applicationDbContext;


        public async Task<CreateOrderItemVm> Handle(CreateOrderItemCommand request, CancellationToken cancellationToken)
        {
            var orderItem = new OrderItem()
            {
                Name = request.Name,
                Quantity = request.Quantity,
                Unit = request.Unit,
                OrderId = request.OrderId
            };

            var response = new CreateOrderItemVm();

            try
            {
                await _applicationDbContext.OrderItems.AddAsync(orderItem, cancellationToken);
                await _applicationDbContext.SaveChangesAsync(cancellationToken);

                response.Id = orderItem.Id;
                response.IsSuccess = true;
            }
            catch { }

            return response;
        }
    }
    }
