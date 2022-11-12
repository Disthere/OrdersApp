using AutoMapper;
using OrdersApp.DAL.Common.Mappings;
using OrdersApp.Domain.Entities.OrdersAggregate;

namespace OrdersApp.DAL.MediatRAccess.OrdersAggregate.OrderItems.Queries.GetOrderItemList
{
    public class OrderItemLookupDto : IMapWith<OrderItem>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Quantity { get; set; }
        public string Unit { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<OrderItem, OrderItemLookupDto>()
                .ForMember(orderItemDto => orderItemDto.Id,
                opt => opt.MapFrom(orderItem => orderItem.Id))
                .ForMember(orderItemDto => orderItemDto.Name,
                opt => opt.MapFrom(orderItem => orderItem.Name))
                .ForMember(orderItemDto => orderItemDto.Quantity,
                opt => opt.MapFrom(orderItem => orderItem.Quantity))
                .ForMember(orderItemDto => orderItemDto.Unit,
                opt => opt.MapFrom(orderItem => orderItem.Unit));
        }
    }
}


