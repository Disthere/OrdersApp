using OrdersApp.DAL.Common.QueryStatuses;
using System.Collections.Generic;

namespace OrdersApp.DAL.MediatRAccess.OrdersAggregate.OrderItems.Queries.GetOrderItemList
{
    public class OrderItemListVm : OperationResult
    {
        public IList<OrderItemLookupDto> OrderItems { get; set; }
    }
}
