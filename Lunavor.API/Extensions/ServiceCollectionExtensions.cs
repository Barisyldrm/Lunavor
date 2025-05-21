using Microsoft.Extensions.DependencyInjection;

namespace Lunavor.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services)
        {
            // API katmanına özel servisler buraya eklenecek
            return services;
        }
    }
} 