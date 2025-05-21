using Microsoft.Extensions.DependencyInjection;

namespace Lunavor.Business.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            //services.AddScoped<IServiceService, ServiceService>();
            // Diğer business servisleri buraya eklenecek
            return services;
        }
    }
} 