using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using OrdersApp.DAL.MediatRAccess.OrdersAggregate.Orders.Commands.CreateOrder;
using OrdersApp.DAL.MediatRAccess.OrdersAggregate.Orders.Queries.GetOrderList;
using OrdersApp.DAL.MediatRAccess.OrdersAggregate.Providers.Queries.GetProviderList;
using OrdersApp.Web.Models.Orders;
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
        //[ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetAll()
        {
            var providersListQuery = await Mediator.Send(new GetProviderListQuery());

            if (providersListQuery.IsFound)
            {
                ViewBag.Providers = providersListQuery.Providers;
            }

            var orderListQuery = await Mediator.Send(new GetOrderListQuery());

            var numbers = orderListQuery.Orders
                .GroupBy(o => o.Number)
                .Select(x => x.FirstOrDefault())
                .Select(std => new { std.Id, std.Number })
                .ToList();

            ViewBag.Orders = orderListQuery.Orders;

            if (orderListQuery.IsFound)
            {
                ViewBag.OrderNumbers = numbers;
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
        public async Task<IActionResult> Create(CreateOrderDto createOrderVm)
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
