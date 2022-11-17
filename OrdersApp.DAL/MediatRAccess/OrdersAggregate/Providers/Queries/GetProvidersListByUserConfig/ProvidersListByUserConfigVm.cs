using OrdersApp.DAL.Common.QueryStatuses;
using System.Collections.Generic;

namespace OrdersApp.DAL.MediatRAccess.OrdersAggregate.Providers.Queries.GetProvidersListByUserConfig
{
    public class ProvidersListByUserConfigVm : OperationResult
    {
        public IList<ProvidersListByUserConfigLookupDto> Providers { get; set; }
    }
}
