using Microsoft.Extensions.DependencyInjection;

namespace CryptoServiceBybit.ServiceBybit
{
    public static class ServiceBybitExtensions
    {
        public static IServiceCollection AddServiceBybit(this IServiceCollection services)
        {
            services.AddSingleton<BaseClient, ServiceBybitClient>();
            return services;
        }
        
        public static IServiceCollection AddServiceBybitTestnet(this IServiceCollection services)
        {
            services.AddSingleton<BaseClient, ServiceBybitTestnetClient>();
            return services;
        }
    }
}
