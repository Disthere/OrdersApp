namespace OrdersApp.Domain.Entities.OrdersAggregate
{
    public class OrderItem : BaseEntity
    {
        public string Name { get; set; }
        public decimal Quantity { get; set; }
        public string Unit { get; set; }

        public int OrderId { get; set; }

        public Order Order { get; set; }
    }
}
