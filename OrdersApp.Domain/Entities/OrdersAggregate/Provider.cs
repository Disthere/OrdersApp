using System.ComponentModel.DataAnnotations.Schema;

namespace OrdersApp.Domain.Entities.OrdersAggregate
{
    public class Provider : BaseEntity
    {
        //[Column(TypeName = "nvarchar(max)")] - использовать при работе с базой данных SQL Server (не SqLite) 
        public string Name { get; set; }
    }
}
