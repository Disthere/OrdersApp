using System.Collections.Generic;

namespace OrdersApp.DAL.MediatRAccess.OrdersAggregate.Providers.Queries.GetProviderList
{
    public class ProviderListVm
    {
        public IList<ProviderLookupDto> Providers { get; set; }
    }
}
