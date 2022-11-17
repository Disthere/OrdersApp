using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.DependencyInjection;
using OrdersApp.DAL.MediatRAccess.OrdersAggregate.Orders.Commands.CreateOrder;
using OrdersApp.DAL.MediatRAccess.OrdersAggregate.Orders.Queries.GetOrderList;
using OrdersApp.DAL.MediatRAccess.OrdersAggregate.Providers.Commands.CreateProvider;
using OrdersApp.DAL.MediatRAccess.OrdersAggregate.Providers.Queries.GetProviderList;
using OrdersApp.Web.Models.Orders;
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


        [HttpGet(Name = "MediatRGetAllOrders")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetAll()
        {
            var providersListQuery = new GetProviderListQuery();

            var vm = await Mediator.Send(providersListQuery);

            ViewBag.Providers = vm.Providers;

            return View();
        }


        public async Task<IActionResult> Create()
        {
            //var providersListQuery = new GetProviderListQuery();

            var providers = await Mediator.Send(new GetProviderListQuery());

            var vm = new CreateOrderViewModel();

            if (providers.IsFound)
            {
                vm.Providers = providers.Providers;

                return View(vm);
            }

            return View();
        }

        [HttpPost]
        //[ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(CreateOrderViewModel createOrderVm)
        {

            if (ModelState.IsValid)
            {
                var createOrderComand = new CreateOrderCommand()
                {
                    Number = createOrderVm.CreateOrderDto.Number,
                    Date = createOrderVm.CreateOrderDto.Date,
                    ProviderId = createOrderVm.CreateOrderDto.ProviderId
                };

                //var command = _mapper.Map<CreateOrderCommand>(createOrderVm.CreateOrderDto);
                //command.Name = ;
                var operationResult = await Mediator.Send(createOrderComand);

                if (operationResult.IsSuccess)
                {
                    return RedirectToAction("GetAll", "Order");
                }

                ModelState.AddModelError("", operationResult.IsSuccess.ToString());
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
