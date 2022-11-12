using AutoMapper;
using OrdersApp.DAL.Common.Mappings;
using OrdersApp.Domain.Entities.OrdersAggregate;
using System;

namespace OrdersApp.DAL.MediatRAccess.OrdersAggregate.Orders.Queries.GetOrderList
{
    public class OrderLookupDto : IMapWith<Order>
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public DateTime Date { get; set; }
        public int ProviderId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Order, OrderLookupDto>()
                .ForMember(orderDto => orderDto.Id,
                opt => opt.MapFrom(order => order.Id))
                .ForMember(orderDto => orderDto.Number,
                opt => opt.MapFrom(order => order.Number))
                .ForMember(orderDto => orderDto.Date,
                opt => opt.MapFrom(order => order.Date))
                .ForMember(orderDto => orderDto.ProviderId,
                opt => opt.MapFrom(order => order.ProviderId));
        }
    }
}


