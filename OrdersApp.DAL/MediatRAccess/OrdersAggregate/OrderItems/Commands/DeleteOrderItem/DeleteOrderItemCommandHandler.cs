using MediatR;
using OrdersApp.DAL.Common.Exceptions;
using OrdersApp.DAL.Persistence;
using OrdersApp.Domain.Entities.OrdersAggregate;
using System.Threading;
using System.Threading.Tasks;

namespace OrdersApp.DAL.MediatRAccess.OrdersAggregate.OrderItems.Commands.DeleteOrderItem
{
    public class DeleteOrderItemCommandHandler : IRequestHandler<DeleteOrderItemCommand>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public DeleteOrderItemCommandHandler(IApplicationDbContext applicationDbContext) =>
            _applicationDbContext = applicationDbContext;


        public async Task<Unit> Handle(DeleteOrderItemCommand request, CancellationToken cancellationToken)
        {
            var entity = await _applicationDbContext.OrderItems
                .FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null)
                throw new NotFoundException(nameof(OrderItem), request.Id);

            _applicationDbContext.OrderItems.Remove(entity);
            await _applicationDbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
