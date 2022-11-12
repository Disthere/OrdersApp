using MediatR;
using Microsoft.EntityFrameworkCore;
using OrdersApp.DAL.Common.Exceptions;
using OrdersApp.DAL.Persistence;
using OrdersApp.Domain.Entities.OrdersAggregate;
using System.Threading;
using System.Threading.Tasks;

namespace OrdersApp.DAL.MediatRAccess.OrdersAggregate.Orders.Commands.UpdateOrder
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public UpdateOrderCommandHandler(IApplicationDbContext applicationDbContext) =>
            _applicationDbContext = applicationDbContext;

        public async Task<Unit> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var entity = await _applicationDbContext.Orders.FirstOrDefaultAsync(
                d => d.Id == request.Id, cancellationToken);

            if (entity == null)
                throw new NotFoundException(nameof(Order), request.Id);

            entity.Number = request.Number;
            entity.Date = request.Date;
            entity.ProviderId = request.ProviderId;

            await _applicationDbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
