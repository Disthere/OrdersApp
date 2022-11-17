using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OrdersApp.DAL.MediatRAccess.OrdersAggregate.Orders.Queries.GetOrdersListByUserConfig;
using OrdersApp.DAL.Persistence;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OrdersApp.DAL.MediatRAccess.OrdersAggregate.Providers.Queries.GetProvidersListByUserConfig
{
    public class GetProvidersListByUserConfigQueryHandler
        : IRequestHandler<GetProvidersListByUserConfigQuery, ProvidersListByUserConfigVm>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;

        public GetProvidersListByUserConfigQueryHandler(IApplicationDbContext applicationDbContext, IMapper mapper) =>
            (_applicationDbContext, _mapper) = (applicationDbContext, mapper);


        public async Task<ProvidersListByUserConfigVm> Handle(GetProvidersListByUserConfigQuery request, CancellationToken cancellationToken)
        {
            var response = new ProvidersListByUserConfigVm();

            try
            {
                response.Providers = await _applicationDbContext.Providers
                .Where(provider =>
                   (string.IsNullOrEmpty(request.Name) || provider.Name == request.Name))
                 .ProjectTo<ProvidersListByUserConfigLookupDto>(_mapper.ConfigurationProvider)
                 .ToListAsync(cancellationToken);
            }
            catch { }

            if (response.Providers != null)
                response.IsFound = true;

            return response;
        }
    }
}
