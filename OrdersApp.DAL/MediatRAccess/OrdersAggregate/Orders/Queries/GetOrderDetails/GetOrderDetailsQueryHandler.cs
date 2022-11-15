﻿using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OrdersApp.DAL.Common.Exceptions;
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
            var entity = await _applicationDbContext.Orders
                .FirstOrDefaultAsync(order =>
                order.Id == request.Id, cancellationToken);

            if (entity == null)
                throw new NotFoundException(nameof(Order), request.Id);

            return _mapper.Map<OrderDetailsVm>(entity);
        }
    }
}