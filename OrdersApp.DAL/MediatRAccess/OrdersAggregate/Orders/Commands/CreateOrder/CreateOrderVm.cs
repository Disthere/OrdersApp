using OrdersApp.DAL.Common.QueryStatuses;

namespace OrdersApp.DAL.MediatRAccess.OrdersAggregate.Orders.Commands.CreateOrder
{
    public class CreateOrderVm : OperationResult
    {
        public int Id { get; set; }
    }
}
