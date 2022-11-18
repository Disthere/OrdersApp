using MediatR;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using OrdersApp.DAL.MediatRAccess.OrdersAggregate.Providers.Queries.GetProviderList;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OrdersApp.Web.Models.Orders
{
    public class CreateOrderViewModel
    {
        public CreateOrderDto CreateOrderDto { get; set; }

        //[Required]
        [ValidateNever]
        public IList<ProviderLookupDto> Providers { get; set; }
                
    }
}
