using AutoMapper;
using OrdersApp.DAL.Common.Mappings;
using OrdersApp.Domain.Entities.OrdersAggregate;

namespace OrdersApp.DAL.MediatRAccess.OrdersAggregate.Providers.Queries.GetProviderList
{
    public class ProviderLookupDto : IMapWith<Provider>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Provider, ProviderLookupDto>()
                .ForMember(providerDto => providerDto.Id,
                opt => opt.MapFrom(provider => provider.Id))
                .ForMember(providerDto => providerDto.Name,
                opt => opt.MapFrom(provider => provider.Name));
        }
    }
}


