using MediatR;
using System;

namespace OrdersApp.DAL.MediatRAccess.OrdersAggregate.Orders.Queries.GetOrdersListByUserConfig
{
    public class GetOrdersListByUserConfigQuery : IRequest<OrdersListByUserConfigVm>
    {
        public string Number { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public int? ProviderId { get; set; }
    }
}
