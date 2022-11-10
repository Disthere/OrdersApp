using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrdersApp.Domain.Entities.OrdersAggregate
{
    public class Provider : BaseEntity
    {
        public string Name { get; set; }

        public List<Order> Orders { get; set; }
    }
}
