using MediatR;

namespace OrdersApp.DAL.MediatRAccess.OrdersAggregate.OrderItems.Commands.DeleteOrderItem
{
    public class DeleteOrderItemCommand : IRequest
    {
        public int Id { get; set; }
    }
}
