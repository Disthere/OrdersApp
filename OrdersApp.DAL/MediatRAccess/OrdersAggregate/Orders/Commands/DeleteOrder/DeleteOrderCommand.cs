using MediatR;

namespace OrdersApp.DAL.MediatRAccess.OrdersAggregate.Orders.Commands.DeleteOrder
{
    public class DeleteOrderCommand : IRequest<DeleteOrderVm>
    {
        public int Id { get; set; }
    }
}
