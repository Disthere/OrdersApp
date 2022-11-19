using AutoMapper;
using OrdersApp.DAL.Common.Mappings;
using OrdersApp.DAL.MediatRAccess.OrdersAggregate.Orders.Queries.GetOrdersListByUserConfig;
using System;

namespace OrdersApp.Web.Models.Orders
{
    public class GetOrdersByUserConfigViewModel : IMapWith<GetOrdersListByUserConfigQuery>
    {
        public string Number { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public int? ProviderId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<GetOrdersByUserConfigViewModel, GetOrdersListByUserConfigQuery>();
        }
    }
}
