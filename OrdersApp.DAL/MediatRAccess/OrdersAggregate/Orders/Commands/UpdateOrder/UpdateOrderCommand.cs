using MediatR;
using System;

namespace OrdersApp.DAL.MediatRAccess.OrdersAggregate.Orders.Commands.UpdateOrder
{
    public class UpdateOrderCommand : IRequest<UpdateOrderVm>
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public DateTime Date { get; set; }
        public int ProviderId { get; set; }
    }
}
