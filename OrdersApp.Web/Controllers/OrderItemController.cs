using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using OrdersApp.DAL.MediatRAccess.OrdersAggregate.OrderItems.Commands.CreateOrderItem;
using OrdersApp.DAL.MediatRAccess.OrdersAggregate.OrderItems.Commands.DeleteOrderItem;
using OrdersApp.DAL.MediatRAccess.OrdersAggregate.OrderItems.Commands.UpdateOrderItem;
using OrdersApp.DAL.MediatRAccess.OrdersAggregate.OrderItems.Queries.GetOrderItemDetails;
using OrdersApp.Web.Models.OrderItems;
using System.Threading.Tasks;

namespace OrdersApp.Web.Controllers
{
    public class OrderItemController : BaseController
    {
        private readonly IMapper _mapper;
        private IMediator _mediator;
        private IMediator Mediator =>
            _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        public OrderItemController(IMapper mapper) =>
            _mapper = mapper;


        // Past: OrderItemController/Get/5
        public async Task<ActionResult> Get([FromRoute] int id)
        {
            if (id != 0)
            {
                var currentOrderItem = await Mediator.Send(new GetOrderItemDetailsQuery() { Id = id });

                if (currentOrderItem.IsFound)
                {
                    ViewBag.OrderItem = currentOrderItem;
                }
            }

            return View();
        }


        // Get: OrderItemController/Create
        [HttpGet]
        public IActionResult Add([FromRoute] int id)
        {
            var vm = new CreateOrderItemViewModel();

            if (id > 0)
            {
                vm.OrderId = id;
                return View(vm);
            }

            return NotFound();
        }


        // POST: OrderItemController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(CreateOrderItemViewModel createOrderItemVm)
        {
            if (ModelState.IsValid)
            {
                var createOrderItemCommand = new CreateOrderItemCommand()
                {
                    OrderId = createOrderItemVm.OrderId,
                    Name = createOrderItemVm.Name,
                    Quantity = createOrderItemVm.Quantity,
                    Unit = createOrderItemVm.Unit
                };

                var operationResult = await Mediator.Send(createOrderItemCommand);

                if (operationResult.IsSuccess)
                {
                    return RedirectToAction("Get", "Order", new { id = createOrderItemVm.OrderId });
                }
            }

            return View(createOrderItemVm);
        }


        // GET: OrderItemController/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var currentOrderItem = await Mediator.Send(new GetOrderItemDetailsQuery() { Id = id });

            var vm = new UpdateOrderItemViewModel();

            if (currentOrderItem.IsFound)
            {
                {
                    vm.Id = currentOrderItem.Id;
                    vm.Name = currentOrderItem.Name;
                    vm.Quantity = currentOrderItem.Quantity;
                    vm.Unit = currentOrderItem.Unit;
                    vm.OrderId = currentOrderItem.OrderId;
                };
            }

            return View(vm);
        }


        //// POST: OrderItemController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UpdateOrderItemViewModel updateOrderItemVm)
        {
            if (ModelState.IsValid)
            {
                var updateOrderItemCommand = new UpdateOrderItemCommand()
                {
                    Id = updateOrderItemVm.Id,
                    Name = updateOrderItemVm.Name,
                    Quantity = updateOrderItemVm.Quantity,
                    Unit = updateOrderItemVm.Unit
                };

                var operationResult = await Mediator.Send(updateOrderItemCommand);

                if (operationResult.IsSuccess)
                {
                    return RedirectToAction("Get", "Order", new { id = operationResult.OrderId });
                }
            }

            return View();
        }


        // POST: OrderItemController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            if (id >= 0)
            {
                var operationResult = await Mediator.Send(new DeleteOrderItemCommand() { Id = id });

                if (operationResult.IsSuccess)
                    return RedirectToAction("Get", "Order", new { id = operationResult.OrderId });
            }

            return BadRequest();
        }
    }
}
