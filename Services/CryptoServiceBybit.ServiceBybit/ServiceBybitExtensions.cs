using Microsoft.Extensions.DependencyInjection;

namespace CryptoServiceBybit.ServiceBybit
{
    public static class ServiceBybitExtensions
    {
        public static IServiceCollection AddClientBybit(this IServiceCollection services)
        {
            services.AddSingleton<BaseClient, ServiceBybitClient>();
            return services;
        }
        
        public static IServiceCollection AddClientBybitTestnet(this IServiceCollection services)
        {
            services.AddSingleton<BaseClient, ServiceBybitTestnetClient>();
            return services;
        }
    }
}
