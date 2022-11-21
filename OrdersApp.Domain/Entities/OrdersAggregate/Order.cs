using System;
using System.Collections.Generic;

namespace OrdersApp.Domain.Entities.OrdersAggregate
{
    public class Order : BaseEntity
    {
        public string Number { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public int ProviderId { get; set; }

        public Provider Provider { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }
}
