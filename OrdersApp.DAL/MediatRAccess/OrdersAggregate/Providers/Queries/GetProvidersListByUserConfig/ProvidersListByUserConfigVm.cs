using System.Collections.Generic;

namespace OrdersApp.DAL.MediatRAccess.OrdersAggregate.Providers.Queries.GetProvidersListByUserConfig
{
    public class ProvidersListByUserConfigVm
    {
        public IList<ProvidersListByUserConfigLookupDto> Providers { get; set; }
    }
}
