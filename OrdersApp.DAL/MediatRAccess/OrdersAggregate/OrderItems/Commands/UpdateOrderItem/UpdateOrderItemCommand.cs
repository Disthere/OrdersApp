using MediatR;

namespace OrdersApp.DAL.MediatRAccess.OrdersAggregate.OrderItems.Commands.UpdateOrderItem
{
    public class UpdateOrderItemCommand : IRequest<UpdateOrderItemVm>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Quantity { get; set; }
        public string Unit { get; set; }
    }
}
