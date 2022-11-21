using MediatR;
using Microsoft.EntityFrameworkCore;
using OrdersApp.DAL.Common.Exceptions;
using OrdersApp.DAL.MediatRAccess.OrdersAggregate.Orders.Commands.UpdateOrder;
using OrdersApp.DAL.Persistence;
using OrdersApp.Domain.Entities.OrdersAggregate;
using System.Threading;
using System.Threading.Tasks;

namespace OrdersApp.DAL.MediatRAccess.OrdersAggregate.OrderItems.Commands.UpdateOrderItem
{
    public class UpdateOrderItemCommandHandler : IRequestHandler<UpdateOrderItemCommand, UpdateOrderItemVm>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public UpdateOrderItemCommandHandler(IApplicationDbContext applicationDbContext) =>
            _applicationDbContext = applicationDbContext;

        public async Task<UpdateOrderItemVm> Handle(UpdateOrderItemCommand request, CancellationToken cancellationToken)
        {
            var entity = new OrderItem();

            try
            {
                entity = await _applicationDbContext.OrderItems.FirstOrDefaultAsync(
                d => d.Id == request.Id, cancellationToken);
            }
            catch { }

            var response = new UpdateOrderItemVm();

            if (entity != null)
            {
                response.IsFound = true;

                entity.Name = request.Name;
                entity.Quantity = request.Quantity;
                entity.Unit = request.Unit;

                try
                {
                    _applicationDbContext.OrderItems.Update(entity);
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
