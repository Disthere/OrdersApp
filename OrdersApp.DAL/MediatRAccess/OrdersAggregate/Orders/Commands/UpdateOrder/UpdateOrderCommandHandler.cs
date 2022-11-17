using MediatR;
using Microsoft.EntityFrameworkCore;
using OrdersApp.DAL.Common.Exceptions;
using OrdersApp.DAL.MediatRAccess.OrdersAggregate.Orders.Commands.DeleteOrder;
using OrdersApp.DAL.MediatRAccess.OrdersAggregate.Providers.Commands.UpdateProvider;
using OrdersApp.DAL.Persistence;
using OrdersApp.Domain.Entities.OrdersAggregate;
using System.Threading;
using System.Threading.Tasks;

namespace OrdersApp.DAL.MediatRAccess.OrdersAggregate.Orders.Commands.UpdateOrder
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, UpdateOrderVm>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public UpdateOrderCommandHandler(IApplicationDbContext applicationDbContext) =>
            _applicationDbContext = applicationDbContext;

        public async Task<UpdateOrderVm> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var entity = new Order();

            try
            {
                entity = await _applicationDbContext.Orders.FirstOrDefaultAsync(
                d => d.Id == request.Id, cancellationToken);
            }
            catch { }

            var response = new UpdateOrderVm();

            if (entity != null)
            {
                response.IsFound = true;

                entity.Number = request.Number;
                entity.Date = request.Date;
                entity.ProviderId = request.ProviderId;

                try
                {
                    _applicationDbContext.Orders.Update(entity);
                    await _applicationDbContext.SaveChangesAsync(cancellationToken);
                    response.IsSuccess = true;
                }
                catch { response.IsError = true; }
            }

            return response;
        }
    }
}
