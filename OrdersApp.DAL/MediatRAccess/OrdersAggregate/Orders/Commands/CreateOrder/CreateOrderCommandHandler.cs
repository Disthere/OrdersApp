using MediatR;
using OrdersApp.DAL.Persistence;
using OrdersApp.Domain.Entities.OrdersAggregate;
using System.Threading;
using System.Threading.Tasks;

namespace OrdersApp.DAL.MediatRAccess.OrdersAggregate.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, CreateOrderVm>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public CreateOrderCommandHandler(IApplicationDbContext applicationDbContext) =>
            _applicationDbContext = applicationDbContext;


        public async Task<CreateOrderVm> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = new Order()
            {
                Number = request.Number,
                Date = request.Date,
                ProviderId = request.ProviderId
            };

            var response = new CreateOrderVm();

            try
            {
                await _applicationDbContext.Orders.AddAsync(order, cancellationToken);
                await _applicationDbContext.SaveChangesAsync(cancellationToken);

                response.Id = order.Id;
                response.IsSuccess = true;
            }
            catch { }
            
            return  response;
        }
    }
}
