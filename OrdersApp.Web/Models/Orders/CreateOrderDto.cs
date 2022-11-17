using AutoMapper;
using OrdersApp.DAL.Common.Mappings;
using OrdersApp.DAL.MediatRAccess.OrdersAggregate.Orders.Commands.CreateOrder;
using System;
using System.ComponentModel.DataAnnotations;

namespace OrdersApp.Web.Models.Orders
{
    public class CreateOrderDto : IMapWith<CreateOrderCommand>
    {

        [Required]
        [Display(Name ="Наименование")]
        public string Number { get; set; }

        [Required]
        [Display(Name = "Дата создания")]
        public DateTime Date { get; set; }

        [Required]
        [Display(Name = "Поставщик")]
        public int ProviderId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateOrderDto, CreateOrderCommand>()
                .ForMember(orderVm => orderVm.Number,
                opt => opt.MapFrom(order => order.Number))
                .ForMember(orderVm => orderVm.Date,
                opt => opt.MapFrom(order => order.Date))
                .ForMember(orderVm => orderVm.ProviderId,
                opt => opt.MapFrom(order => order.ProviderId)); ;
        }
    }
}
