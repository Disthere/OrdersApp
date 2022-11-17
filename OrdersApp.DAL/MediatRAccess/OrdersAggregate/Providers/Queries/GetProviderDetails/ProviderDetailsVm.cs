using AutoMapper;
using OrdersApp.DAL.Common.Mappings;
using OrdersApp.DAL.Common.QueryStatuses;
using OrdersApp.Domain.Entities.OrdersAggregate;

namespace OrdersApp.DAL.MediatRAccess.OrdersAggregate.Providers.Queries.GetProviderDetails
{
    public class ProviderDetailsVm : OperationResult, IMapWith<Provider>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Provider, ProviderDetailsVm>()
                .ForMember(providerVm => providerVm.Id,
                opt => opt.MapFrom(provider => provider.Id))
                .ForMember(providerVm => providerVm.Name,
                opt => opt.MapFrom(provider => provider.Name));
        }
    }
}
