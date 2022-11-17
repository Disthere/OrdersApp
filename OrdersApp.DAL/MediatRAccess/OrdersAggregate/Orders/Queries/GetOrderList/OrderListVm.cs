using OrdersApp.DAL.Common.QueryStatuses;
using System.Collections.Generic;

namespace OrdersApp.DAL.MediatRAccess.OrdersAggregate.Orders.Queries.GetOrderList
{
    public class OrderListVm : OperationResult
    {
        public IList<OrderLookupDto> Orders { get; set; }
    }
}
