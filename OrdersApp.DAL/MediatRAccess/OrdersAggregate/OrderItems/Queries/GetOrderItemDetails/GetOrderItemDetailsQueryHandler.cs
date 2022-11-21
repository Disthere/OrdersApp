using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OrdersApp.DAL.Persistence;
using OrdersApp.Domain.Entities.OrdersAggregate;
using System.Threading;
using System.Threading.Tasks;

namespace OrdersApp.DAL.MediatRAccess.OrdersAggregate.OrderItems.Queries.GetOrderItemDetails
{
    public class GetOrderItemDetailsQueryHandler
        : IRequestHandler<GetOrderItemDetailsQuery, OrderItemDetailsVm>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;

        public GetOrderItemDetailsQueryHandler(IApplicationDbContext applicationDbContext, IMapper mapper) =>
            (_applicationDbContext, _mapper) = (applicationDbContext, mapper);


        public async Task<OrderItemDetailsVm> Handle(GetOrderItemDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = new OrderItem();

            try
            {
                entity = await _applicationDbContext.OrderItems
                .FirstOrDefaultAsync(orderItem =>
                orderItem.Id == request.Id, cancellationToken);
            }
            catch { }

            var response = new OrderItemDetailsVm();

            if (entity != null)
            {
                response = _mapper.Map<OrderItemDetailsVm>(entity);
                response.IsFound = true;
            }

            return response;
        }
    }
}
