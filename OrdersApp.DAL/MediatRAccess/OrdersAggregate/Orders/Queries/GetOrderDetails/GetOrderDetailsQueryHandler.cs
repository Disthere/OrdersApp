using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OrdersApp.DAL.Common.Exceptions;
using OrdersApp.DAL.MediatRAccess.OrdersAggregate.Orders.Commands.CreateOrder;
using OrdersApp.DAL.Persistence;
using OrdersApp.Domain.Entities.OrdersAggregate;
using System.Threading;
using System.Threading.Tasks;

namespace OrdersApp.DAL.MediatRAccess.OrdersAggregate.Orders.Queries.GetOrderDetails
{
    public class GetOrderDetailsQueryHandler
        : IRequestHandler<GetOrderDetailsQuery, OrderDetailsVm>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;

        public GetOrderDetailsQueryHandler(IApplicationDbContext applicationDbContext, IMapper mapper) =>
            (_applicationDbContext, _mapper) = (applicationDbContext, mapper);


        public async Task<OrderDetailsVm> Handle(GetOrderDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = new Order();

            try
            {
                entity = await _applicationDbContext.Orders
                    .Include(provider => provider.Provider)
                    .Include(orderItems => orderItems.OrderItems)
                    .FirstOrDefaultAsync(order =>
                     order.Id == request.Id, cancellationToken);
            }
            catch { }

            var response = new OrderDetailsVm();

            if (entity != null)
            {
                response = _mapper.Map<OrderDetailsVm>(entity);
                response.IsFound = true;
            }

            return response;
        }
    }
}
