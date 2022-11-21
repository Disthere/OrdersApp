using AutoMapper;
using OrdersApp.DAL.Common.Mappings;
using OrdersApp.DAL.MediatRAccess.OrdersAggregate.OrderItems.Commands.CreateOrderItem;
using OrdersApp.DAL.MediatRAccess.OrdersAggregate.OrderItems.Commands.UpdateOrderItem;
using OrdersApp.Web.Models.OrderItems.Options;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace OrdersApp.Web.Models.OrderItems
{
    public class UpdateOrderItemViewModel : IMapWith<UpdateOrderItemCommand>, IValidatableObject
    {
        [Required]
        public int Id { get; set; }

        public int OrderId { get; set; }

        [Required(ErrorMessage = "Незаполненное поле")]
        [Display(Name = "Наименование")]
        public string Name { get; set; }

        [Required]
        [Range(typeof(decimal), "0", "999999999999", ErrorMessage = "Недопустимый диапазон")]
        [RegularExpression(@"^(\d+).(\d{3})$", ErrorMessage = "Допустимый диапазон - 0,00 - 9999999999,99")]
        [DataType(DataType.Currency, ErrorMessage = "Неверный числовой формат")]
        [Display(Name = "Количество")]
        public decimal Quantity { get; set; }

        [Required(ErrorMessage = "Незаполненное поле")]
        [Display(Name = "Единицы измерения")]
        public string Unit { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateOrderItemCommand, CreateOrderItemViewModel>();                
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            var finder = new SameNameFinder();

            if (finder.NameFound(OrderId, Name))
            {
                errors.Add(new ValidationResult("Имя компонента совпадает с именем заказа", new List<string>() { "Name" }));
            }

            return errors;
        }
    }
}
