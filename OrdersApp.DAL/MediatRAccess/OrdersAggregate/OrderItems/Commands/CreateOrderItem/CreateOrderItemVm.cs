using OrdersApp.DAL.Common.QueryStatuses;

namespace OrdersApp.DAL.MediatRAccess.OrdersAggregate.OrderItems.Commands.CreateOrderItem
{
    public class CreateOrderItemVm : OperationResult
    {
        public int Id { get; set; }
    }
}
