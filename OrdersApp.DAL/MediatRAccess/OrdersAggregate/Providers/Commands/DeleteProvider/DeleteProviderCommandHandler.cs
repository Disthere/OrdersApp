using MediatR;
using OrdersApp.DAL.Common.Exceptions;
using OrdersApp.DAL.MediatRAccess.OrdersAggregate.Orders.Commands.DeleteOrder;
using OrdersApp.DAL.Persistence;
using OrdersApp.Domain.Entities.OrdersAggregate;
using System.Threading;
using System.Threading.Tasks;

namespace OrdersApp.DAL.MediatRAccess.OrdersAggregate.Providers.Commands.DeleteProvider
{
    public class DeleteProviderCommandHandler : IRequestHandler<DeleteProviderCommand, DeleteProviderVm>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public DeleteProviderCommandHandler(IApplicationDbContext applicationDbContext) =>
            _applicationDbContext = applicationDbContext;


        public async Task<DeleteProviderVm> Handle(DeleteProviderCommand request, CancellationToken cancellationToken)
        {
            var response = new DeleteProviderVm();

            var entity = new Provider();

            try
            {
                entity = await _applicationDbContext.Providers
                   .FindAsync(new object[] { request.Id }, cancellationToken);
            }
            catch { }

            if (entity != null)
            {
                response.IsFound = true;

                try
                {
                    _applicationDbContext.Providers.Remove(entity);
                    await _applicationDbContext.SaveChangesAsync(cancellationToken);
                    response.IsSuccess = true;
                }
                catch { response.IsError = true; }
            }

            return response;
        }
    }
}
