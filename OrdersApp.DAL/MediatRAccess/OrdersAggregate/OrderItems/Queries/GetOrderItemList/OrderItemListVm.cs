using System.Collections.Generic;

namespace OrdersApp.DAL.MediatRAccess.OrdersAggregate.OrderItems.Queries.GetOrderItemList
{
    public class OrderItemListVm
    {
        public IList<OrderItemLookupDto> OrderItems { get; set; }
    }
}
