using OrdersApp.DAL.MediatRAccess.OrdersAggregate.Orders.Queries.GetOrdersListByUserConfig;
using System.Collections.Generic;
using System.Linq;

namespace OrdersApp.Web.Models.Orders.Options
{
    public class OrderFiltration
    {
        private readonly IList<OrdersListByUserConfigLookupDto> _orders;

        public OrderFiltration(IList<OrdersListByUserConfigLookupDto> orders) =>
             _orders = orders;

        public List<string> GetOrderNumbers()
        {
            var orderNumbers = _orders
                        .GroupBy(o => o.Number)
                        .Select(x => x.FirstOrDefault())
                        .Select(s => s.Number)
                        .ToList();

            if (orderNumbers.Any())
                return orderNumbers;
            else
                return new List<string>() { "Не найдено" };
        }
    }
}
