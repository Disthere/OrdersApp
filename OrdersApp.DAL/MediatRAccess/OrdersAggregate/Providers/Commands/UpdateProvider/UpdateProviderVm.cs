using OrdersApp.DAL.Common.QueryStatuses;

namespace OrdersApp.DAL.MediatRAccess.OrdersAggregate.Providers.Commands.UpdateProvider
{
    public class UpdateProviderVm : OperationResult
    {
        public int Id { get; set; }
    }
}
