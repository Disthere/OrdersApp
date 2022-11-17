using MediatR;

namespace OrdersApp.DAL.MediatRAccess.OrdersAggregate.Providers.Commands.DeleteProvider
{
    public class DeleteProviderCommand : IRequest<DeleteProviderVm>
    {
        public int Id { get; set; }
    }
}
