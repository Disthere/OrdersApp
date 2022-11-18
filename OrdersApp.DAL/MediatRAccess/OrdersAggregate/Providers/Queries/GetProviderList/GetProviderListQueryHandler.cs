using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OrdersApp.DAL.MediatRAccess.OrdersAggregate.Orders.Queries.GetOrderList;
using OrdersApp.DAL.Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace OrdersApp.DAL.MediatRAccess.OrdersAggregate.Providers.Queries.GetProviderList
{
    public class GetProviderListQueryHandler
        : IRequestHandler<GetProviderListQuery, ProviderListVm>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;

        public GetProviderListQueryHandler(IApplicationDbContext applicationDbContext, IMapper mapper) =>
            (_applicationDbContext, _mapper) = (applicationDbContext, mapper);
       

        public async Task<ProviderListVm> Handle(GetProviderListQuery request, CancellationToken cancellationToken)
        {
            var response = new ProviderListVm();

            try
            {
                response.Providers = await _applicationDbContext.Providers
                 .ProjectTo<ProviderLookupDto>(_mapper.ConfigurationProvider)
                 .ToListAsync(cancellationToken);
            }
            catch { }

            if (response.Providers.Count != 0)
                response.IsFound = true;

            return response;
        }
    }
}
