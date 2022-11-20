using AutoMapper;
using OrdersApp.DAL.Common.Mappings;
using OrdersApp.DAL.Common.QueryStatuses;
using OrdersApp.Domain.Entities.OrdersAggregate;
using System;
using System.Collections.Generic;

namespace OrdersApp.DAL.MediatRAccess.OrdersAggregate.Orders.Queries.GetOrderDetails
{
    public class OrderDetailsVm : OperationResult, IMapWith<Order>
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public DateTime Date { get; set; }
        public int ProviderId { get; set; }
        public Provider Provider { get; set; }
        public List<OrderItem> OrderItems { get; set; }

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
                opt => opt.MapFrom(order => order.ProviderId))
                .ForMember(orderVm => orderVm.Provider,
                opt => opt.MapFrom(order => order.Provider))
                .ForMember(orderVm => orderVm.OrderItems,
                opt => opt.MapFrom(order => order.OrderItems));
        }
    }
}
