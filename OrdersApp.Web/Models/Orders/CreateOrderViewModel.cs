using MediatR;
using OrdersApp.DAL.MediatRAccess.OrdersAggregate.Providers.Queries.GetProviderList;
using System.Collections.Generic;

namespace OrdersApp.Web.Models.Orders
{
    public class CreateOrderViewModel
    {
        public CreateOrderDto CreateOrderDto { get; set; }

        public IList<ProviderLookupDto> Providers { get; set; }
                
    }
}
