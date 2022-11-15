using MediatR;

namespace OrdersApp.DAL.MediatRAccess.OrdersAggregate.OrderItems.Queries.GetOrderItemsListByUserConfig
{
    public class GetOrderItemsListByUserConfigQuery : IRequest<OrderItemsListByUserConfigVm>
    {
        public string Name { get; set; }
        public string Unit { get; set; }
    }
}
