using MediatR;

namespace OrdersApp.DAL.MediatRAccess.OrdersAggregate.Providers.Queries.GetProviderDetails
{
    public class GetProviderDetailsQuery : IRequest<ProviderDetailsVm>
    {
        public int Id { get; set; }
    }
}
