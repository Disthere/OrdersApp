using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OrdersApp.DAL.Persistence;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OrdersApp.DAL.MediatRAccess.OrdersAggregate.OrderItems.Queries.GetOrderItemsListByUserConfig
{
    public class GetOrderItemsListByUserConfigQueryHandler
        : IRequestHandler<GetOrderItemsListByUserConfigQuery, OrderItemsListByUserConfigVm>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;

        public GetOrderItemsListByUserConfigQueryHandler(IApplicationDbContext applicationDbContext, IMapper mapper) =>
            (_applicationDbContext, _mapper) = (applicationDbContext, mapper);


        public async Task<OrderItemsListByUserConfigVm> Handle(GetOrderItemsListByUserConfigQuery request, CancellationToken cancellationToken)
        {
            var response = new OrderItemsListByUserConfigVm();

            try
            {
                response.OrderItems = await _applicationDbContext.OrderItems
                 .Where(orderId => orderId.OrderId == request.OrderId)
                 .Where(orderItem =>
                   (string.IsNullOrEmpty(request.Name) || orderItem.Name == request.Name)
                 && (string.IsNullOrEmpty(request.Unit) || orderItem.Unit == request.Unit))
                 .ProjectTo<OrderItemsListByUserConfigLookupDto>(_mapper.ConfigurationProvider)
                 .ToListAsync(cancellationToken);
            }
            catch { }

            if (response.OrderItems.Count != 0)
                response.IsFound = true;

            return response;
        }
    }
}
