using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using OrdersApp.DAL.MediatRAccess.OrdersAggregate.OrderItems.Commands.CreateOrderItem;
using OrdersApp.DAL.MediatRAccess.OrdersAggregate.Orders.Commands.DeleteOrder;
using OrdersApp.DAL.MediatRAccess.OrdersAggregate.Orders.Commands.UpdateOrder;
using OrdersApp.DAL.MediatRAccess.OrdersAggregate.Orders.Queries.GetOrderDetails;
using OrdersApp.DAL.MediatRAccess.OrdersAggregate.Orders.Queries.GetOrdersListByUserConfig;
using OrdersApp.DAL.MediatRAccess.OrdersAggregate.Providers.Queries.GetProviderList;
using OrdersApp.Web.Models.OrderItems;
using OrdersApp.Web.Models.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
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

                var orderNumbers = orderList.Orders
                    .GroupBy(o => o.Number)
                    .Select(x => x.FirstOrDefault())
                    .Select(s => s.Number)
                    .ToList();

                //var orderNumbers = orderList.Orders
                //    .GroupBy(o => o.Number)
                //    .Select(x => x.FirstOrDefault())
                //    .Select(std => new { std.Id, std.Number })
                //    .ToList();

                ViewBag.OrderNumbers = orderNumbers;
            }

            return View();
        }


        // Post: OrderController/GetAll
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> GetAll(GetOrdersByUserConfigViewModel getOrdersByUserConfigViewModel)
        {
            //if (!ModelState.IsValid)
            //{
            //    var providersListQuery = await Mediator.Send(new GetProviderListQuery());

            //    if (providersListQuery.IsFound)
            //    {
            //        ViewBag.Providers = providersListQuery.Providers;
            //    }

            //    var orderListQuery = new GetOrdersListByUserConfigQuery()
            //    {
            //        DateFrom = DateTime.Now.AddMonths(-1),
            //        DateTo = DateTime.Now
            //    };

            //    var orderList = await Mediator.Send(orderListQuery);

            //    if (orderList.IsFound)
            //    {
            //        ViewBag.Orders = orderList.Orders;

            //        var orderNumbers = orderList.Orders
            //            .GroupBy(o => o.Number)
            //            .Select(x => x.FirstOrDefault())
            //            .Select(s => s.Number)
            //            .ToList();

            //        ViewBag.OrderNumbers = orderNumbers;
            //    }
            //}

            if (ModelState.IsValid)
            {
                //var orderListQuery = _mapper.Map<GetOrdersListByUserConfigQuery>(getOrdersByUserConfigViewModel);
                var providersListQuery = await Mediator.Send(new GetProviderListQuery());

                if (providersListQuery.IsFound)
                {
                    ViewBag.Providers = providersListQuery.Providers;
                }


                var orderListQuery = new GetOrdersListByUserConfigQuery()
                {
                    Number = getOrdersByUserConfigViewModel.Number,
                    DateFrom = getOrdersByUserConfigViewModel.DateFrom,
                    DateTo = getOrdersByUserConfigViewModel.DateTo,
                    ProviderId = getOrdersByUserConfigViewModel.ProviderId
                };

                var orderList = await Mediator.Send(orderListQuery);

                if (orderList.IsFound)
                {
                    ViewBag.Orders = orderList.Orders;

                    var orderNumbers = orderList.Orders
                        .GroupBy(o => o.Number)
                        .Select(x => x.FirstOrDefault())
                        .Select(s => s.Number)
                        .ToList();

                    ViewBag.OrderNumbers = orderNumbers;
                }
                else
                {
                    ViewBag.OrderNumbers = new List<string>() { "Не найдено" };
                }
            }
            return View();
        }

        // GET: OrderController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // Past: OrderController/Get
        public async Task<ActionResult> Get([FromRoute] int id)
        {
            if (id != 0)
            {
                var currentOrder = await Mediator.Send(new GetOrderDetailsQuery() { Id = id });

                if (currentOrder.IsFound)
                {
                    ViewBag.Order = currentOrder;

                    var orderItemNames = currentOrder.OrderItems
                    .GroupBy(o => o.Name)
                    .Select(x => x.FirstOrDefault())
                    .Select(s => s.Name)
                    .ToList();

                    if (orderItemNames.Any())
                        ViewBag.OrderItemNames = orderItemNames;
                    else
                    {
                        ViewBag.OrderItemNames = new List<string>() { "Не найдено" };
                    }

                    var orderItemUnits = currentOrder.OrderItems
                    .GroupBy(o => o.Unit)
                    .Select(x => x.FirstOrDefault())
                    .Select(s => s.Unit)
                    .ToList();

                    if (orderItemUnits.Any())
                        ViewBag.OrderItemUnits = orderItemUnits;
                    else
                    {
                        ViewBag.OrderItemUnits = new List<string>() { "Не найдено" };
                    }
                }

                return View();
            }

            return View("Error");

            //var providersListQuery = await Mediator.Send(new GetProviderListQuery());

            //if (providersListQuery.IsFound)
            //{
            //    ViewBag.Providers = providersListQuery.Providers;
            //}

            //var orderListQuery = new GetOrdersListByUserConfigQuery()
            //{
            //    DateFrom = DateTime.Now.AddMonths(-1),
            //    DateTo = DateTime.Now
            //};

            //var orderList = await Mediator.Send(orderListQuery);

            //if (orderList.IsFound)
            //{
            //    ViewBag.Orders = orderList.Orders;

            //    var orderNumbers = orderList.Orders
            //        .GroupBy(o => o.Number)
            //        .Select(x => x.FirstOrDefault())
            //        .Select(s => s.Number)
            //        .ToList();

            //    //var orderNumbers = orderList.Orders
            //    //    .GroupBy(o => o.Number)
            //    //    .Select(x => x.FirstOrDefault())
            //    //    .Select(std => new { std.Id, std.Number })
            //    //    .ToList();

            //    ViewBag.OrderNumbers = orderNumbers;
            //}

            //return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Get(GetOrdersByUserConfigViewModel getOrdersByUserConfigViewModel)
        {
            //if (!ModelState.IsValid)
            //{
            //    var providersListQuery = await Mediator.Send(new GetProviderListQuery());

            //    if (providersListQuery.IsFound)
            //    {
            //        ViewBag.Providers = providersListQuery.Providers;
            //    }

            //    var orderListQuery = new GetOrdersListByUserConfigQuery()
            //    {
            //        DateFrom = DateTime.Now.AddMonths(-1),
            //        DateTo = DateTime.Now
            //    };

            //    var orderList = await Mediator.Send(orderListQuery);

            //    if (orderList.IsFound)
            //    {
            //        ViewBag.Orders = orderList.Orders;

            //        var orderNumbers = orderList.Orders
            //            .GroupBy(o => o.Number)
            //            .Select(x => x.FirstOrDefault())
            //            .Select(s => s.Number)
            //            .ToList();

            //        ViewBag.OrderNumbers = orderNumbers;
            //    }
            //}

            if (ModelState.IsValid)
            {
                //var orderListQuery = _mapper.Map<GetOrdersListByUserConfigQuery>(getOrdersByUserConfigViewModel);
                var providersListQuery = await Mediator.Send(new GetProviderListQuery());

                if (providersListQuery.IsFound)
                {
                    ViewBag.Providers = providersListQuery.Providers;
                }


                var orderListQuery = new GetOrdersListByUserConfigQuery()
                {
                    Number = getOrdersByUserConfigViewModel.Number,
                    DateFrom = getOrdersByUserConfigViewModel.DateFrom,
                    DateTo = getOrdersByUserConfigViewModel.DateTo,
                    ProviderId = getOrdersByUserConfigViewModel.ProviderId
                };

                var orderList = await Mediator.Send(orderListQuery);

                if (orderList.IsFound)
                {
                    ViewBag.Orders = orderList.Orders;

                    var orderNumbers = orderList.Orders
                        .GroupBy(o => o.Number)
                        .Select(x => x.FirstOrDefault())
                        .Select(s => s.Number)
                        .ToList();

                    ViewBag.OrderNumbers = orderNumbers;
                }
                else
                {
                    ViewBag.OrderNumbers = new List<string>() { "Не найдено" };
                }
            }
            return View();
        }


        // Get: OrderController/Create
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


        // POST: OrderController/Create
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


        // GET: OrderController/Edit/5
        public async Task<IActionResult> Edit([FromRoute] int id)
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
                // ViewBag.CurrentOrder = currentOrder;

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

                //var currentOrder = await Mediator.Send(new GetOrderDetailsQuery() { Id = orderId });

                //if (currentOrder.IsFound)
                //    ViewBag.OrderDetails = currentOrder;
            }
            //var providers = await Mediator.Send(new GetProviderListQuery());

            //var vm = new CreateOrderViewModel();

            //if (providers.IsFound)
            //{
            //    createOrderVm.Providers = providers.Providers;
            //}

            //return View(createOrderVm);


            if (ModelState.IsValid)
            {
                //var updateOrderCommand = _mapper.Map<UpdateOrderCommand>(updateOrderVm);

                var updateOrderCommand = new UpdateOrderCommand()
                {
                    Id = updateOrderVm.Id,
                    Number = updateOrderVm.Number,
                    Date = updateOrderVm.Date,
                    ProviderId = updateOrderVm.ProviderId
                };

                var operationResult = await Mediator.Send(updateOrderCommand);

                if (operationResult.IsSuccess)
                {
                    return RedirectToAction("GetAll", "Order");
                }
            }

            return View("Error");
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

            return View("Error");
        }
    }
}
