using AutoMapper;
using OrdersApp.DAL.Common.Mappings;
using OrdersApp.Domain.Entities.OrdersAggregate;
using System;

namespace OrdersApp.DAL.MediatRAccess.OrdersAggregate.Orders.Queries.GetOrdersListByUserConfig
{
    public class OrdersListByUserConfigLookupDto : IMapWith<Order>
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public DateTime? Date { get; set; }
        public int? ProviderId { get; set; }
        public Provider Provider { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Order, OrdersListByUserConfigLookupDto>();
        }
    }
}


