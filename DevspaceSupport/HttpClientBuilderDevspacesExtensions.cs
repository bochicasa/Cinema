using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace DevspaceSupport
{
    public static class HttpClientBuilderDevspacesExtensions
    {
        public static IHttpClientBuilder AddDevspacesSupport(this IHttpClientBuilder builder)
        {
            builder.AddHttpMessageHandler<DevspacesMessageHandler>();
            return builder;
        }
    }
}
