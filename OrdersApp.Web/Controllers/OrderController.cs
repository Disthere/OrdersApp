using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using OrdersApp.DAL.MediatRAccess.OrdersAggregate.Orders.Commands.CreateOrder;
using OrdersApp.DAL.MediatRAccess.OrdersAggregate.Orders.Queries.GetOrderList;
using OrdersApp.DAL.MediatRAccess.OrdersAggregate.Orders.Queries.GetOrdersListByUserConfig;
using OrdersApp.DAL.MediatRAccess.OrdersAggregate.Providers.Queries.GetProviderList;
using OrdersApp.Web.Models.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
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


        //[HttpGet(Name = "MediatRGetAllOrders")]
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


        [HttpPost]
        public async Task<ActionResult> GetAll(GetOrdersByUserConfigViewModel getOrdersByUserConfigViewModel)
        {
            if (!ModelState.IsValid)
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

                    ViewBag.OrderNumbers = orderNumbers;
                }
            }

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
                    ViewBag.OrderNumbers = new List<string>() {"Не найдено"};
                }
            }
            return View();
        }

        public async Task<IActionResult> Create()
        {

            var providersListQuery = await Mediator.Send(new GetProviderListQuery());

            if (providersListQuery.IsFound)
            {
                ViewBag.Providers = providersListQuery.Providers;
            }

            return View();
        }

        [HttpPost]
        //[ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(CreateOrderViewModel createOrderVm)
        {
            if (!ModelState.IsValid)
            {
                var providers = await Mediator.Send(new GetProviderListQuery());

                ViewBag.Providers = providers.Providers;

                //var providers = await Mediator.Send(new GetProviderListQuery());

                //var vm = new CreateOrderViewModel();

                //if (providers.IsFound)
                //{
                //    createOrderVm.Providers = providers.Providers;
                //}

                //return View(createOrderVm);
            }

            if (ModelState.IsValid)
            {
                var createOrderComand = new CreateOrderCommand()
                {
                    Number = createOrderVm.Number,
                    Date = createOrderVm.Date,
                    ProviderId = createOrderVm.ProviderId
                };

                //var command = _mapper.Map<CreateOrderCommand>(createOrderVm.CreateOrderDto);
                //command.Name = ;
                var operationResult = await Mediator.Send(createOrderComand);

                if (operationResult.IsSuccess)
                {
                    return RedirectToAction("GetAll", "Order");
                }
            }

            return View(createOrderVm);

        }


        // GET: OrderController
        public ActionResult Index()
        {
            return View();
        }

        // GET: OrderController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }



        // POST: OrderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Created(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrderController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OrderController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrderController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OrderController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
