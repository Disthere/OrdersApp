﻿using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System;
using Microsoft.Extensions.DependencyInjection;

namespace OrdersApp.Web.Infrastructure.AccessToServicesFromOutside
{
    public class HttpContextServiceProviderProxy : IServiceProviderProxy
    {
        private readonly IHttpContextAccessor contextAccessor;

        public HttpContextServiceProviderProxy(IHttpContextAccessor contextAccessor)
        {
            this.contextAccessor = contextAccessor;
        }

        public T GetService<T>()
        {
            return contextAccessor.HttpContext.RequestServices.GetService<T>();
        }

        public IEnumerable<T> GetServices<T>()
        {
            return contextAccessor.HttpContext.RequestServices.GetServices<T>();
        }

        public object GetService(Type type)
        {
            return contextAccessor.HttpContext.RequestServices.GetService(type);
        }

        public IEnumerable<object> GetServices(Type type)
        {
            return contextAccessor.HttpContext.RequestServices.GetServices(type);
        }
    }
    
}
