using Microsoft.Extensions.DependencyInjection;

namespace DevspaceSupport
{
    public static class ServiceCollectionDevspacesExtensions
    {
        public static IServiceCollection AddDevspaces(this IServiceCollection services)
        {
            services.AddTransient<DevspacesMessageHandler>();
            return services;
        }
    }
}
