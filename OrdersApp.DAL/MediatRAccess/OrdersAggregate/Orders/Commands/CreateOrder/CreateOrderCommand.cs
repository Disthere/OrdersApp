using MediatR;
using System;

namespace OrdersApp.DAL.MediatRAccess.OrdersAggregate.Orders.Commands.CreateOrder
{
    public class CreateOrderCommand : IRequest<int>
    {
        public string Number { get; set; }
        public DateTime Date { get; set; }
        public int ProviderId { get; set; }
    }
}
