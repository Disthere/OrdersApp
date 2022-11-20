using AutoMapper;
using OrdersApp.DAL.Common.Mappings;
using OrdersApp.DAL.MediatRAccess.OrdersAggregate.OrderItems.Queries.GetOrderItemsListByUserConfig;
using OrdersApp.DAL.MediatRAccess.OrdersAggregate.Orders.Queries.GetOrdersListByUserConfig;
using System;

namespace OrdersApp.Web.Models.OrderItems
{
    public class GetOrderItemsByUserConfigViewModel : IMapWith<GetOrderItemsListByUserConfigQuery>
    {
        public string Name { get; set; }
        public string Unit { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<GetOrderItemsByUserConfigViewModel, GetOrderItemsListByUserConfigQuery>();
        }
    }
}
