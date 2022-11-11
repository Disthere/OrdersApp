using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OrdersApp.DAL.Common.Exceptions;
using OrdersApp.DAL.Persistence;
using OrdersApp.Domain.Entities.OrdersAggregate;
using System.Threading;
using System.Threading.Tasks;

namespace OrdersApp.DAL.MediatRAccess.OrdersAggregate.Providers.Queries.GetProviderDetails
{
    public class GetProviderDetailsQueryHandler
        : IRequestHandler<GetProviderDetailsQuery, ProviderDetailsVm>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;

        public GetProviderDetailsQueryHandler(IApplicationDbContext applicationDbContext, IMapper mapper) =>
            (_applicationDbContext, _mapper) = (applicationDbContext, mapper);


        public async Task<ProviderDetailsVm> Handle(GetProviderDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _applicationDbContext.Providers
                .FirstOrDefaultAsync(provider =>
                provider.Id == request.Id, cancellationToken);

            if (entity == null)
                throw new NotFoundException(nameof(Provider), request.Id);

            return _mapper.Map<ProviderDetailsVm>(entity);
        }
    }
}
