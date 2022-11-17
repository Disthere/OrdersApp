using OrdersApp.DAL.Common.QueryStatuses;

namespace OrdersApp.DAL.MediatRAccess.OrdersAggregate.OrderItems.Commands.UpdateOrderItem
{
    public class UpdateOrderItemVm : OperationResult
    {
        public int Id { get; set; }
    }
}
