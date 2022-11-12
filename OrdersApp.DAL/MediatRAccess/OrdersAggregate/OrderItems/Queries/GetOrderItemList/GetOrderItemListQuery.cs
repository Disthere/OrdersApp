using MediatR;

namespace OrdersApp.DAL.MediatRAccess.OrdersAggregate.OrderItems.Queries.GetOrderItemList
{
    public class GetOrderItemListQuery : IRequest<OrderItemListVm>
    {
    }
}
