using OrdersApp.DAL.Common.QueryStatuses;

namespace OrdersApp.DAL.MediatRAccess.OrdersAggregate.Orders.Commands.UpdateOrder
{
    public class UpdateOrderVm : OperationResult
    {
        public int Id { get; set; }
    }
}
