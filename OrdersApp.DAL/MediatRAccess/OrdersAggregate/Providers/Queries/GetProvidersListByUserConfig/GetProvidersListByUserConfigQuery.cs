using MediatR;

namespace OrdersApp.DAL.MediatRAccess.OrdersAggregate.Providers.Queries.GetProvidersListByUserConfig
{
    public class GetProvidersListByUserConfigQuery : IRequest<ProvidersListByUserConfigVm>
    {
        public string Name { get; set; }

    }
}
