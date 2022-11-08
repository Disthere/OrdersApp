using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersApp.Domain.Entities.OrdersAggregate
{
    public class Order : BaseEntity
    {
        public string Number { get; set; }
        public DateTime Date { get; set; }
        public int ProviderId { get; set; }
    }
}
