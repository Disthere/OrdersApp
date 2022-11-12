using MediatR;

namespace OrdersApp.DAL.MediatRAccess.OrdersAggregate.Orders.Commands.DeleteOrder
{
    public class DeleteOrderCommand : IRequest
    {
        public int Id { get; set; }
    }
}
