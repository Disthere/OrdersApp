using System.Collections.Generic;
using System;

namespace OrdersApp.Web.Infrastructure.AccessToServicesFromOutside
{
    public interface IServiceProviderProxy
    {
        T GetService<T>();
        IEnumerable<T> GetServices<T>();
        object GetService(Type type);
        IEnumerable<object> GetServices(Type type);
    }
}
