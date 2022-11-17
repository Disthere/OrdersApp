using MediatR;
using OrdersApp.DAL.Persistence;
using OrdersApp.Domain.Entities.OrdersAggregate;
using System.Threading;
using System.Threading.Tasks;

namespace OrdersApp.DAL.MediatRAccess.OrdersAggregate.Providers.Commands.CreateProvider
{
    public class CreateProviderCommandHandler : IRequestHandler<CreateProviderCommand, CreateProviderVm>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public CreateProviderCommandHandler(IApplicationDbContext applicationDbContext) =>
            _applicationDbContext = applicationDbContext;


        public async Task<CreateProviderVm> Handle(CreateProviderCommand request, CancellationToken cancellationToken)
        {
            var provider = new Provider()
            {
                Name = request.Name
            };

            var response = new CreateProviderVm();

            try
            {
                await _applicationDbContext.Providers.AddAsync(provider, cancellationToken);
                await _applicationDbContext.SaveChangesAsync(cancellationToken);
                response.Id = provider.Id;
                response.IsSuccess = true;
            }
            catch { }

            return response;
        }
    }
}
