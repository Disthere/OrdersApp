using MediatR;

namespace OrdersApp.DAL.MediatRAccess.OrdersAggregate.Providers.Commands.CreateProvider
{
    public class CreateProviderCommand : IRequest<CreateProviderVm>
    {
        public string Name { get; set; }
    }
}
