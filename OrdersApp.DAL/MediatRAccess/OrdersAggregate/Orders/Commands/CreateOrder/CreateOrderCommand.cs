using MediatR;
using System;

namespace OrdersApp.DAL.MediatRAccess.OrdersAggregate.Orders.Commands.CreateOrder
{
    public class CreateOrderCommand : IRequest<CreateOrderVm>
    {
        public string Number { get; set; }
        public DateTime Date { get; set; }
        public int ProviderId { get; set; }
    }
}
