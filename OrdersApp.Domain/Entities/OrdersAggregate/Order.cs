using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersApp.Domain.Entities.OrdersAggregate
{
    public class Order : BaseEntity
    {
        //[Column(TypeName = "nvarchar(max)")] - использовать при работе с базой данных SQL Server (не SqLite)
        public string Number { get; set; }

        [Column(TypeName = "datetime2(7)")]
        public DateTime Date { get; set; }
        public int ProviderId { get; set; }
    }
}
