using System.Collections.Generic;

namespace OrdersApp.DAL.MediatRAccess.OrdersAggregate.OrderItems.Queries.GetOrderItemsListByUserConfig
{
    public class OrderItemsListByUserConfigVm
    {
        public IList<OrderItemsListByUserConfigLookupDto> OrderItems { get; set; }
    }
}
