using OrdersApp.DAL.Common.QueryStatuses;
using System.Collections.Generic;

namespace OrdersApp.DAL.MediatRAccess.OrdersAggregate.Orders.Queries.GetOrdersListByUserConfig
{
    public class OrdersListByUserConfigVm : OperationResult
    {
        public IList<OrdersListByUserConfigLookupDto> Orders { get; set; }
    }
}
