using MediatR;

namespace OrdersApp.DAL.MediatRAccess.OrdersAggregate.Orders.Queries.GetOrderList
{
    public class GetOrderListQuery : IRequest<OrderListVm>
    {
    }
}
