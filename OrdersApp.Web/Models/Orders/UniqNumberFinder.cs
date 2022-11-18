using MediatR;
using OrdersApp.DAL.MediatRAccess.OrdersAggregate.Orders.Queries.GetOrdersListByUserConfig;
using OrdersApp.Web.Infrastructure.AccessToServicesFromOutside;

namespace OrdersApp.Web.Models.Orders
{
    public class UniqNumberFinder
    {
        public bool NumberFound(int providerId, string number)
        {
            var numberQuery = new GetOrdersListByUserConfigQuery()
            {
                Number = number,
                ProviderId = providerId
            };

            var mediator = ServiceLocator.ServiceProvider.GetService<IMediator>();

            var responce = mediator.Send(numberQuery).Result;

            if (responce.IsFound)
                return true;

            return false;
        }
    }
}
