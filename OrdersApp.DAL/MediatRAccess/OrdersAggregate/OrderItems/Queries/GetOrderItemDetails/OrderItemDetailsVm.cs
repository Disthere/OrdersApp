using AutoMapper;
using OrdersApp.DAL.Common.Mappings;
using OrdersApp.DAL.Common.QueryStatuses;
using OrdersApp.Domain.Entities.OrdersAggregate;

namespace OrdersApp.DAL.MediatRAccess.OrdersAggregate.OrderItems.Queries.GetOrderItemDetails
{
    public class OrderItemDetailsVm : OperationResult, IMapWith<OrderItem>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Quantity { get; set; }
        public string Unit { get; set; }
        public int OrderId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<OrderItem, OrderItemDetailsVm>()
                .ForMember(orderItemVm => orderItemVm.Id,
                opt => opt.MapFrom(orderItem => orderItem.Id))
                .ForMember(orderItemVm => orderItemVm.Name,
                opt => opt.MapFrom(orderItem => orderItem.Name))
                .ForMember(orderItemVm => orderItemVm.Quantity,
                opt => opt.MapFrom(orderItem => orderItem.Quantity))
                .ForMember(orderItemVm => orderItemVm.Unit,
                opt => opt.MapFrom(orderItem => orderItem.Unit))
                .ForMember(orderItemVm => orderItemVm.OrderId,
                opt => opt.MapFrom(orderItem => orderItem.OrderId));
        }
    }
}
