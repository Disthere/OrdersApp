using MediatR;
using Microsoft.EntityFrameworkCore;
using OrdersApp.DAL.Common.Exceptions;
using OrdersApp.DAL.MediatRAccess.OrdersAggregate.Orders.Commands.UpdateOrder;
using OrdersApp.DAL.Persistence;
using OrdersApp.Domain.Entities.OrdersAggregate;
using System.Threading;
using System.Threading.Tasks;

namespace OrdersApp.DAL.MediatRAccess.OrdersAggregate.Providers.Commands.UpdateProvider
{
    public class UpdateProviderCommandHandler : IRequestHandler<UpdateProviderCommand, UpdateProviderVm>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public UpdateProviderCommandHandler(IApplicationDbContext applicationDbContext) =>
            _applicationDbContext = applicationDbContext;

        public async Task<UpdateProviderVm> Handle(UpdateProviderCommand request, CancellationToken cancellationToken)
        {
            var entity = new Provider();

            try
            {
                entity = await _applicationDbContext.Providers.FirstOrDefaultAsync(
                d => d.Id == request.Id, cancellationToken);
            }
            catch { }

            var response = new UpdateProviderVm();

            if (entity != null)
            {
                response.IsFound = true;

                entity.Name = request.Name;

                try
                {
                    _applicationDbContext.Providers.Update(entity);
                    await _applicationDbContext.SaveChangesAsync(cancellationToken);
                    response.IsSuccess = true;
                }
                catch { response.IsError = true; }
            }

            return response;
        }
    }
}
