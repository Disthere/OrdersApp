﻿using MediatR;

namespace OrdersApp.DAL.MediatRAccess.OrdersAggregate.OrderItems.Commands.CreateOrderItem
{
    public class CreateOrderItemCommand : IRequest<CreateOrderItemVm>
    {
        public string Name { get; set; }
        public decimal Quantity { get; set; }
        public string Unit { get; set; }
    }
}
