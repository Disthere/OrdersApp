using MediatR;
using OrdersApp.DAL.Common.Exceptions;
using OrdersApp.DAL.MediatRAccess.OrdersAggregate.Orders.Commands.DeleteOrder;
using OrdersApp.DAL.Persistence;
using OrdersApp.Domain.Entities.OrdersAggregate;
using System.Threading;
using System.Threading.Tasks;

namespace OrdersApp.DAL.MediatRAccess.OrdersAggregate.OrderItems.Commands.DeleteOrderItem
{
    public class DeleteOrderItemCommandHandler : IRequestHandler<DeleteOrderItemCommand, DeleteOrderItemVm>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public DeleteOrderItemCommandHandler(IApplicationDbContext applicationDbContext) =>
            _applicationDbContext = applicationDbContext;


        public async Task<DeleteOrderItemVm> Handle(DeleteOrderItemCommand request, CancellationToken cancellationToken)
        {
            var response = new DeleteOrderItemVm();

            var entity = new OrderItem();

            try
            {
                entity = await _applicationDbContext.OrderItems
                   .FindAsync(new object[] { request.Id }, cancellationToken);
            }
            catch { }

            if (entity != null)
            {
                response.IsFound = true;

                try
                {
                    _applicationDbContext.OrderItems.Remove(entity);
                    await _applicationDbContext.SaveChangesAsync(cancellationToken);
                    response.IsSuccess = true;

                    response.Id = entity.Id;
                    response.OrderId = entity.OrderId;
                }
                catch { response.IsError = true; }
            }

            return response;
        }
    }
}
