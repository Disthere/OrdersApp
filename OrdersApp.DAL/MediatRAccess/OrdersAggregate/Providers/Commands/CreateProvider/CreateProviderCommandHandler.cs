using MediatR;
using OrdersApp.DAL.Persistence;
using OrdersApp.Domain.Entities.OrdersAggregate;
using System.Threading;
using System.Threading.Tasks;

namespace OrdersApp.DAL.MediatRAccess.OrdersAggregate.Providers.Commands.CreateProvider
{
    public class CreateProviderCommandHandler : IRequestHandler<CreateProviderCommand, int>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public CreateProviderCommandHandler(IApplicationDbContext applicationDbContext) =>
            _applicationDbContext = applicationDbContext;


        public async Task<int> Handle(CreateProviderCommand request, CancellationToken cancellationToken)
        {
            var provider = new Provider()
            {
                Name = request.Name
            };

            await _applicationDbContext.Providers.AddAsync(provider, cancellationToken);
            await _applicationDbContext.SaveChangesAsync(cancellationToken);

            return provider.Id;
        }
    }
}
