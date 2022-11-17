using AutoMapper;
using OrdersApp.DAL.Common.Mappings;
using OrdersApp.DAL.MediatRAccess.OrdersAggregate.Orders.Commands.UpdateOrder;
using System;
using System.ComponentModel.DataAnnotations;

namespace OrdersApp.Web.Models.Orders
{
    public class UpdateOrderDto : IMapWith<UpdateOrderCommand>
    {
        [Required]
        public int Id { get; set; }
        public string Number { get; set; }
        public DateTime Date { get; set; }
        public int ProviderId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateOrderDto, UpdateOrderCommand>();
        }
    }
}

