using System.Collections.Generic;

namespace OrdersApp.DAL.MediatRAccess.OrdersAggregate.Orders.Queries.GetOrderList
{
    public class OrderListVm
    {
        public IList<OrderLookupDto> Orders { get; set; }
    }
}
