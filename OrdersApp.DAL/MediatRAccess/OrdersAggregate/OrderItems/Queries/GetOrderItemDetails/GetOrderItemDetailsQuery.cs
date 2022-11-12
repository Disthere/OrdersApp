using MediatR;

namespace OrdersApp.DAL.MediatRAccess.OrdersAggregate.OrderItems.Queries.GetOrderItemDetails
{
    public class GetOrderItemDetailsQuery : IRequest<OrderItemDetailsVm>
    {
        public int Id { get; set; }
    }
}
