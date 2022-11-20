using MediatR;
using OrdersApp.DAL.MediatRAccess.OrdersAggregate.Orders.Queries.GetOrdersListByUserConfig;
using OrdersApp.Web.Infrastructure.AccessToServicesFromOutside;
using System.Linq;

namespace OrdersApp.Web.Models.OrdersItems
{
    public class SameNameFinder
    {
        public bool NameFound(int orderId, string name)
        {
            var numberQuery = new GetOrdersListByUserConfigQuery()
            {
                Number = name
            };

            var mediator = ServiceLocator.ServiceProvider.GetService<IMediator>();

            var responce = mediator.Send(numberQuery).Result;

            if (responce.IsFound)
            {
                var order = responce.Orders
                    .Where(order => order.Id == orderId)
                    .FirstOrDefault();

                if (order != null)
                    return true;
            }

            return false;
        }
    }
}
