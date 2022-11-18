using OrdersApp.DAL.Common.QueryStatuses;
using System.Collections.Generic;

namespace OrdersApp.DAL.MediatRAccess.OrdersAggregate.OrderItems.Queries.GetOrderItemsListByUserConfig
{
    public class OrderItemsListByUserConfigVm : OperationResult
    {
        public IList<OrderItemsListByUserConfigLookupDto> OrderItems { get; set; }
    }
}
