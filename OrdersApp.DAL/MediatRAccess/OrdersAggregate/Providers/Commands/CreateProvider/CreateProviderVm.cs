using OrdersApp.DAL.Common.QueryStatuses;

namespace OrdersApp.DAL.MediatRAccess.OrdersAggregate.Providers.Commands.CreateProvider
{
    public class CreateProviderVm : OperationResult
    {
        public int Id { get; set; }
    }
}
