using MediatR;
using OrdersApp.DAL.Common.Exceptions;
using OrdersApp.DAL.MediatRAccess.OrdersAggregate.Orders.Commands.CreateOrder;
using OrdersApp.DAL.Persistence;
using OrdersApp.Domain.Entities.OrdersAggregate;
using System.Threading;
using System.Threading.Tasks;

namespace OrdersApp.DAL.MediatRAccess.OrdersAggregate.Orders.Commands.DeleteOrder
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand, DeleteOrderVm>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public DeleteOrderCommandHandler(IApplicationDbContext applicationDbContext) =>
            _applicationDbContext = applicationDbContext;


        public async Task<DeleteOrderVm> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var response = new DeleteOrderVm();

            var entity = new Order();

            try
            {
                entity = await _applicationDbContext.Orders
                   .FindAsync(new object[] { request.Id }, cancellationToken);
            }
            catch { }

            if (entity != null)
            {
                response.IsFound = true;

                try
                {
                    _applicationDbContext.Orders.Remove(entity);
                    await _applicationDbContext.SaveChangesAsync(cancellationToken);
                    response.IsSuccess = true;
                }
                catch { response.IsError = true; }
            }

            return response;
        }
    }
}
