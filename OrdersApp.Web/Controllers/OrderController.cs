using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using OrdersApp.DAL.MediatRAccess.OrdersAggregate.OrderItems.Queries.GetOrderItemsListByUserConfig;
using OrdersApp.DAL.MediatRAccess.OrdersAggregate.Orders.Commands.CreateOrder;
using OrdersApp.DAL.MediatRAccess.OrdersAggregate.Orders.Commands.DeleteOrder;
using OrdersApp.DAL.MediatRAccess.OrdersAggregate.Orders.Commands.UpdateOrder;
using OrdersApp.DAL.MediatRAccess.OrdersAggregate.Orders.Queries.GetOrderDetails;
using OrdersApp.DAL.MediatRAccess.OrdersAggregate.Orders.Queries.GetOrdersListByUserConfig;
using OrdersApp.DAL.MediatRAccess.OrdersAggregate.Providers.Queries.GetProviderList;
using OrdersApp.Domain.Entities.OrdersAggregate;
using OrdersApp.Web.Models.OrderItems;
using OrdersApp.Web.Models.OrderItems.Options;
using OrdersApp.Web.Models.Orders;
using OrdersApp.Web.Models.Orders.Options;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrdersApp.Web.Controllers
{
    public class OrderController : BaseController
    {
        private readonly IMapper _mapper;
        private IMediator _mediator;
        private IMediator Mediator =>
            _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        public OrderController(IMapper mapper) =>
            _mapper = mapper;


        // Get: OrderController/GetAll
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var providersListQuery = await Mediator.Send(new GetProviderListQuery());

            if (providersListQuery.IsFound)
            {
                ViewBag.Providers = providersListQuery.Providers;
            }

            var orderListQuery = new GetOrdersListByUserConfigQuery()
            {
                DateFrom = DateTime.Now.AddMonths(-1),
                DateTo = DateTime.Now
            };

            var orderList = await Mediator.Send(orderListQuery);

            if (orderList.IsFound)
            {
                ViewBag.Orders = orderList.Orders;
            }
            var filtration = new OrderFiltration(orderList.Orders);

            ViewBag.OrderNumbers = filtration.GetOrderNumbers();

            return View();
        }


        // Post: OrderController/GetAll
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> GetAll(GetOrdersByUserConfigViewModel getOrdersByUserConfigVm)
        {
            if (ModelState.IsValid)
            {
                var providersListQuery = await Mediator.Send(new GetProviderListQuery());

                if (providersListQuery.IsFound)
                    ViewBag.Providers = providersListQuery.Providers;

                var orderListQuery = _mapper.Map<GetOrdersListByUserConfigQuery>(getOrdersByUserConfigVm);

                var orderList = await Mediator.Send(orderListQuery);

                if (orderList.IsFound)
                    ViewBag.Orders = orderList.Orders;

                var filtration = new OrderFiltration(orderList.Orders);

                ViewBag.OrderNumbers = filtration.GetOrderNumbers();
            }
            return View();
        }


        // Get: OrderController/Get/5
        [HttpGet]
        public async Task<ActionResult> Get([FromRoute] int id)
        {
            var vm = new GetOrderItemsByUserConfigViewModel();

            if (id != 0)
            {
                vm.OrderId = id;

                var currentOrder = await Mediator.Send(new GetOrderDetailsQuery() { Id = id });

                if (currentOrder.IsFound)
                {
                    ViewBag.Order = currentOrder;
                    ViewBag.OrderItems = currentOrder.OrderItems;

                    var filtration = new OrderItemFiltration(currentOrder.OrderItems);

                    ViewBag.OrderItemNames = filtration.GetOrderItemNames();
                    ViewBag.OrderItemUnits = filtration.GetOrderItemUnits();
                }

                return View(vm);
            }

            return BadRequest();
        }


        // Post: OrderController/Get/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Get(GetOrderItemsByUserConfigViewModel getOrderItemsByUserConfigVm)
        {
            if (ModelState.IsValid)
            {
                var currentOrder = await Mediator.Send(new GetOrderDetailsQuery() { Id = getOrderItemsByUserConfigVm.OrderId });

                if (currentOrder.IsFound)
                    ViewBag.Order = currentOrder;

                var orderItemsListQuery = _mapper.Map<GetOrderItemsListByUserConfigQuery>(getOrderItemsByUserConfigVm);

                var orderItemList = await Mediator.Send(orderItemsListQuery);

                if (orderItemList.IsFound)
                {
                    ViewBag.OrderItems = orderItemList.OrderItems;

                    List<OrderItem> orderItems = new List<OrderItem>();

                    foreach (var item in orderItemList.OrderItems)
                    {
                        orderItems.Add(new OrderItem()
                        {
                            Id = item.Id,
                            Name = item.Name,
                            Quantity = item.Quantity,
                            Unit = item.Unit
                        });
                    };

                    var filtration = new OrderItemFiltration(orderItems);

                    ViewBag.OrderItemNames = filtration.GetOrderItemNames();
                    ViewBag.OrderItemUnits = filtration.GetOrderItemUnits();
                }
            }

            return View();
        }


        // Get: OrderController/Create
        public async Task<IActionResult> Create()
        {
            var providersListQuery = await Mediator.Send(new GetProviderListQuery());

            if (providersListQuery.IsFound)
            {
                ViewBag.Providers = providersListQuery.Providers;
            }

            return View();
        }


        // POST: OrderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateOrderViewModel createOrderVm)
        {
            if (!ModelState.IsValid)
            {
                var providers = await Mediator.Send(new GetProviderListQuery());

                ViewBag.Providers = providers.Providers;
            }

            if (ModelState.IsValid)
            {
                //_mapper.Map<CreateOrderCommand>(createOrderVm);
                var createOrderCommand =
                new CreateOrderCommand()
                {
                    Number = createOrderVm.Number,
                    Date = createOrderVm.Date,
                    ProviderId = createOrderVm.ProviderId
                };

                var operationResult = await Mediator.Send(createOrderCommand);

                if (operationResult.IsSuccess)
                    return RedirectToAction("GetAll", "Order");
            }

            return View();
        }


        // GET: OrderController/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var providersListQuery = await Mediator.Send(new GetProviderListQuery());

            if (providersListQuery.IsFound)
            {
                ViewBag.Providers = providersListQuery.Providers;
            }

            var currentOrder = await Mediator.Send(new GetOrderDetailsQuery() { Id = id });

            var vm = new UpdateOrderViewModel();

            if (currentOrder.IsFound)
            {
                {
                    vm.Id = id;
                    vm.Number = currentOrder.Number;
                    vm.Date = currentOrder.Date;
                    vm.ProviderId = currentOrder.ProviderId;
                };
            }
            return View(vm);
        }


        //// POST: OrderController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UpdateOrderViewModel updateOrderVm)
        {
            if (!ModelState.IsValid)
            {
                var providers = await Mediator.Send(new GetProviderListQuery());

                ViewBag.Providers = providers.Providers;
            }

            if (ModelState.IsValid)
            {
                var updateOrderCommand = _mapper.Map<UpdateOrderCommand>(updateOrderVm);
                
                var operationResult = await Mediator.Send(updateOrderCommand);

                if (operationResult.IsSuccess)
                    return RedirectToAction("GetAll", "Order");
            }

            return View(updateOrderVm);
        }


        // POST: OrderController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            if (id >= 0)
            {
                var operationResult = await Mediator.Send(new DeleteOrderCommand() { Id = id });

                if (operationResult.IsSuccess)
                    return RedirectToAction("GetAll", "Order");
            }

            return BadRequest();
        }
    }
}
