using AutoMapper;
using OrdersApp.DAL.Common.Mappings;
using OrdersApp.Domain.Entities.OrdersAggregate;
using System;

namespace OrdersApp.DAL.MediatRAccess.OrdersAggregate.Orders.Queries.GetOrderDetails
{
    public class OrderDetailsVm : IMapWith<Order>
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public DateTime Date { get; set; }
        public int ProviderId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Order, OrderDetailsVm>()
                .ForMember(orderVm => orderVm.Id,
                opt => opt.MapFrom(order => order.Id))
                .ForMember(orderVm => orderVm.Number,
                opt => opt.MapFrom(order => order.Number))
                .ForMember(orderVm => orderVm.Date,
                opt => opt.MapFrom(order => order.Date))
                .ForMember(orderVm => orderVm.ProviderId,
                opt => opt.MapFrom(order => order.ProviderId));
        }
    }
}
