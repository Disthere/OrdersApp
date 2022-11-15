using AutoMapper;
using OrdersApp.DAL.Common.Mappings;
using OrdersApp.Domain.Entities.OrdersAggregate;

namespace OrdersApp.DAL.MediatRAccess.OrdersAggregate.OrderItems.Queries.GetOrderItemsListByUserConfig
{
    public class OrderItemsListByUserConfigLookupDto : IMapWith<OrderItem>
    {
        public string Name { get; set; }
        public string Unit { get; set; }
               
        public void Mapping(Profile profile)
        {
            profile.CreateMap<OrderItem, OrderItemsListByUserConfigLookupDto>();
        }
    }
}


