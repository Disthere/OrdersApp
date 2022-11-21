using OrdersApp.DAL.MediatRAccess.OrdersAggregate.Orders.Queries.GetOrderDetails;
using OrdersApp.Domain.Entities.OrdersAggregate;
using System.Collections.Generic;
using System.Linq;

namespace OrdersApp.Web.Models.OrderItems.Options
{
    public class OrderItemFiltration
    {
        private readonly List<OrderItem> _orderItems;

        public OrderItemFiltration(List<OrderItem> orderItems) =>
             _orderItems = orderItems;

        public List<string> GetOrderItemNames()
        {
            var orderItemNames = _orderItems
                    .GroupBy(o => o.Name)
                    .Select(x => x.FirstOrDefault())
                    .Select(s => s.Name)
                    .ToList();

            if (orderItemNames.Any())
                return orderItemNames;
            else
                return new List<string>() { "Не найдено" };

        }

        public List<string> GetOrderItemUnits()
        {
            var orderItemUnits = _orderItems
                    .GroupBy(o => o.Unit)
                    .Select(x => x.FirstOrDefault())
                    .Select(s => s.Unit)
                    .ToList();

            if (orderItemUnits.Any())
                return orderItemUnits;
            else
                return new List<string>() { "Не найдено" };

        }

    }
}
