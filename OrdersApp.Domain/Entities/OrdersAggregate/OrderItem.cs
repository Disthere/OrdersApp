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

        //[Column(TypeName = "nvarchar(max)")] - использовать при работе с базой данных SQL Server (не SqLite)
        public string Name { get; set; }
                
        [Column(TypeName = "decimal(18, 3)")]
        public decimal Quantity { get; set; }

        //[Column(TypeName = "nvarchar(max)")]
        public string Unit { get; set; }
    }
}
