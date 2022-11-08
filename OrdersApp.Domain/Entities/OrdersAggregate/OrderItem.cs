using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersApp.Domain.Entities.OrdersAggregate
{
    public class OrderItem : BaseEntity
    {
        public int OrderId { get; set; }
        public string Name { get; set; }

        
        [Column(TypeName = "decimal(18, 3)")]
        public decimal Quantity { get; set; }
        public string Unit { get; set; }
    }
}
