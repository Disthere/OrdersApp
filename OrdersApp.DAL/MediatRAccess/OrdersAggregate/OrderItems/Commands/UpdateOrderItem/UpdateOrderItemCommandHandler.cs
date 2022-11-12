using MediatR;
using Microsoft.EntityFrameworkCore;
using OrdersApp.DAL.Common.Exceptions;
using OrdersApp.DAL.Persistence;
using OrdersApp.Domain.Entities.OrdersAggregate;
using System.Threading;
using System.Threading.Tasks;

namespace OrdersApp.DAL.MediatRAccess.OrdersAggregate.OrderItems.Commands.UpdateOrderItem
{
    public class UpdateOrderItemCommandHandler : IRequestHandler<UpdateOrderItemCommand>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public UpdateOrderItemCommandHandler(IApplicationDbContext applicationDbContext) =>
            _applicationDbContext = applicationDbContext;

        public async Task<Unit> Handle(UpdateOrderItemCommand request, CancellationToken cancellationToken)
        {
            var entity = await _applicationDbContext.OrderItems.FirstOrDefaultAsync(
                d => d.Id == request.Id, cancellationToken);

            if (entity == null)
                throw new NotFoundException(nameof(OrderItem), request.Id);

            entity.Name = request.Name;
            entity.Quantity = request.Quantity;
            entity.Unit = request.Unit;

            await _applicationDbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
