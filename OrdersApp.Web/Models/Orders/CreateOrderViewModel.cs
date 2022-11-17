using MediatR;
using OrdersApp.DAL.MediatRAccess.OrdersAggregate.Providers.Queries.GetProviderList;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OrdersApp.Web.Models.Orders
{
    public class CreateOrderViewModel
    {
        public CreateOrderDto CreateOrderDto { get; set; }

        [Required]
        public IList<ProviderLookupDto> Providers { get; set; }
                
    }
}
