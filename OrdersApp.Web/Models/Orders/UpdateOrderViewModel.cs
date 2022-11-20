﻿using AutoMapper;
using AutoMapper.Configuration.Annotations;
using OrdersApp.DAL.Common.Mappings;
using OrdersApp.DAL.MediatRAccess.OrdersAggregate.Orders.Commands.CreateOrder;
using OrdersApp.DAL.MediatRAccess.OrdersAggregate.Orders.Commands.UpdateOrder;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OrdersApp.Web.Models.Orders
{
    public class UpdateOrderViewModel : IMapWith<UpdateOrderCommand>
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Незаполненное поле")]
        [Display(Name = "Наименование")]
        public string Number { get; set; }

        [Required]
        [DataType(DataType.Date, ErrorMessage = "Неверный формат даты")]
        [Display(Name = "Дата создания")]
        public DateTime Date { get; set; }

        [Range(1, 1000, ErrorMessage = "Необходимо выбрать значение")]
        [Required(ErrorMessage = "Незаполненное поле")]
        [Display(Name = "Поставщик")]
        public int ProviderId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateOrderViewModel, UpdateOrderCommand>();
                //.IgnoreAllPropertiesWithAnInaccessibleSetter()
                //.IgnoreAllSourcePropertiesWithAnInaccessibleSetter()
    //.IgnoreAllUnmapped();
                
                //.ForMember(orderVm => orderVm.Id,
                //opt => opt.MapFrom(order => order.Id))
                //.ForMember(orderVm => orderVm.Number,
                //opt => opt.MapFrom(order => order.Number))
                //.ForMember(orderVm => orderVm.Date,
                //opt => opt.MapFrom(order => order.Date))
                //.ForMember(orderVm => orderVm.ProviderId,
                //opt => opt.MapFrom(order => order.ProviderId))
                //.ForAllMembers(opts => opts.Ignore());
        }

        
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            var finder = new UniqNumberFinder();

            if (finder.NumberFound(this.ProviderId, this.Number))
            {
                errors.Add(new ValidationResult("У этого поставщика уже есть заказ с таким наименованием", new List<string>() { "Number" }));
            }

            return errors;
        }
    }
}

