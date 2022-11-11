using MediatR;

namespace OrdersApp.DAL.MediatRAccess.OrdersAggregate.Providers.Queries.GetProviderList
{
    public class GetProviderListQuery : IRequest<ProviderListVm>
    {
    }
}
