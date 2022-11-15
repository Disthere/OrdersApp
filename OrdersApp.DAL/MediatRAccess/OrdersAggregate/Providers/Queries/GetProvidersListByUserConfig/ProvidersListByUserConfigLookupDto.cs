using AutoMapper;
using OrdersApp.DAL.Common.Mappings;
using OrdersApp.Domain.Entities.OrdersAggregate;

namespace OrdersApp.DAL.MediatRAccess.OrdersAggregate.Providers.Queries.GetProvidersListByUserConfig
{
    public class ProvidersListByUserConfigLookupDto : IMapWith<Provider>
    {
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Provider, ProvidersListByUserConfigLookupDto>();
        }
    }
}


