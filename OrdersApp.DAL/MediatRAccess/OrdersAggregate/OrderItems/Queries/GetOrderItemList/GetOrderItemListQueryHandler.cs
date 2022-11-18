using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OrdersApp.DAL.MediatRAccess.OrdersAggregate.Orders.Queries.GetOrderList;
using OrdersApp.DAL.Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace OrdersApp.DAL.MediatRAccess.OrdersAggregate.OrderItems.Queries.GetOrderItemList
{
    public class GetOrderItemListQueryHandler
        : IRequestHandler<GetOrderItemListQuery, OrderItemListVm>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;

        public GetOrderItemListQueryHandler(IApplicationDbContext applicationDbContext, IMapper mapper) =>
            (_applicationDbContext, _mapper) = (applicationDbContext, mapper);


        public async Task<OrderItemListVm> Handle(GetOrderItemListQuery request, CancellationToken cancellationToken)
        {
            var response = new OrderItemListVm();

            try
            {
                response.OrderItems = await _applicationDbContext.OrderItems
                 .ProjectTo<OrderItemLookupDto>(_mapper.ConfigurationProvider)
                 .ToListAsync(cancellationToken);
            }
            catch { }

            if (response.OrderItems.Count != 0)
                response.IsFound = true;

            return response;
        }
    }
}
