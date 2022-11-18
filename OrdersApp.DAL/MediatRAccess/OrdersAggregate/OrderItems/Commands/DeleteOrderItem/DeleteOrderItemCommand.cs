using MediatR;

namespace OrdersApp.DAL.MediatRAccess.OrdersAggregate.OrderItems.Commands.DeleteOrderItem
{
    public class DeleteOrderItemCommand : IRequest<DeleteOrderItemVm>
    {
        public int Id { get; set; }
    }
}
