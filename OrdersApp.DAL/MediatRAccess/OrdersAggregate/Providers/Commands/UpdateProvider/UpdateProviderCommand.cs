using MediatR;

namespace OrdersApp.DAL.MediatRAccess.OrdersAggregate.Providers.Commands.UpdateProvider
{
    public class UpdateProviderCommand : IRequest<UpdateProviderVm>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
