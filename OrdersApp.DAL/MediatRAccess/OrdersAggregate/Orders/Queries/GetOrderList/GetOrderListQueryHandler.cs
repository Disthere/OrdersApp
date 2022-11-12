using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OrdersApp.DAL.Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace OrdersApp.DAL.MediatRAccess.OrdersAggregate.Orders.Queries.GetOrderList
{
    public class GetOrderListQueryHandler
        : IRequestHandler<GetOrderListQuery, OrderListVm>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;

        public GetOrderListQueryHandler(IApplicationDbContext applicationDbContext, IMapper mapper) =>
            (_applicationDbContext, _mapper) = (applicationDbContext, mapper);


        public async Task<OrderListVm> Handle(GetOrderListQuery request, CancellationToken cancellationToken)
        {
            var ordersQuery = await _applicationDbContext.Orders
                 .ProjectTo<OrderLookupDto>(_mapper.ConfigurationProvider)
                 .ToListAsync(cancellationToken);

            return new OrderListVm { Orders = ordersQuery };
        }
    }
}
