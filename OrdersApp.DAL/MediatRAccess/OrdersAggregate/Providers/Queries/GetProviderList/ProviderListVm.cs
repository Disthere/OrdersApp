using OrdersApp.DAL.Common.QueryStatuses;
using System.Collections.Generic;

namespace OrdersApp.DAL.MediatRAccess.OrdersAggregate.Providers.Queries.GetProviderList
{
    public class ProviderListVm : OperationResult
    {
        public IList<ProviderLookupDto> Providers { get; set; }
    }
}
