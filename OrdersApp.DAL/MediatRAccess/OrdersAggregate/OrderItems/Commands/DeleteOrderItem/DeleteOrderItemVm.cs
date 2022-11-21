using OrdersApp.DAL.Common.QueryStatuses;

namespace OrdersApp.DAL.MediatRAccess.OrdersAggregate.OrderItems.Commands.DeleteOrderItem
{
    public class DeleteOrderItemVm : OperationResult
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
    }
}
