using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OrdersApp.DAL.MediatRAccess.OrdersAggregate.Orders.Queries.GetOrderList;
using OrdersApp.DAL.Persistence;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OrdersApp.DAL.MediatRAccess.OrdersAggregate.Orders.Queries.GetOrdersListByUserConfig
{
    public class GetOrdersListByUserConfigQueryHandler
        : IRequestHandler<GetOrdersListByUserConfigQuery, OrdersListByUserConfigVm>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;

        public GetOrdersListByUserConfigQueryHandler(IApplicationDbContext applicationDbContext, IMapper mapper) =>
            (_applicationDbContext, _mapper) = (applicationDbContext, mapper);


        public async Task<OrdersListByUserConfigVm> Handle(GetOrdersListByUserConfigQuery request, CancellationToken cancellationToken)
        {
            var response = new OrdersListByUserConfigVm();

            try
            {
                response.Orders = await _applicationDbContext.Orders
                .Where(order =>
                (string.IsNullOrEmpty(request.Number) || order.Number == request.Number)
                && (string.IsNullOrEmpty(request.ProviderId.ToString()) || order.ProviderId == request.ProviderId)
                && (string.IsNullOrEmpty(request.DateFrom.ToString()) || order.Date >= request.DateFrom)
                && (string.IsNullOrEmpty(request.DateTo.ToString()) || order.Date <= request.DateTo))
                 .ProjectTo<OrdersListByUserConfigLookupDto>(_mapper.ConfigurationProvider)
                 .ToListAsync(cancellationToken);
            }
            catch { }

            if (response.Orders != null)
                response.IsFound = true;

            return response;
        }
    }
}
