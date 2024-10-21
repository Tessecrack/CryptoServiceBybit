using CryptoServiceBybit.Processor.Processors;
using CryptoServiceBybit.ServiceBybit;
using Microsoft.Extensions.DependencyInjection;

namespace CryptoServiceBybit.Processor.DI
{
    public static class RequestsProcessorExtensions
    {
        public static IServiceCollection AddRequestsProcessor<T>(this IServiceCollection services) where T : BaseClient
        {
            services.AddSingleton<RequestProcessor<T>>();
            return services;
        }
    }
}
