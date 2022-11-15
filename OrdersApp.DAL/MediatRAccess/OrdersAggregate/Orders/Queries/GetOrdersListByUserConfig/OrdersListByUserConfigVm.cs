using System.Collections.Generic;

namespace OrdersApp.DAL.MediatRAccess.OrdersAggregate.Orders.Queries.GetOrdersListByUserConfig
{
    public class OrdersListByUserConfigVm
    {
        public IList<OrdersListByUserConfigLookupDto> Orders { get; set; }
    }
}
