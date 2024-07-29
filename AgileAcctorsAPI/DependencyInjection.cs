using ApiAggregatorServices.Interfaces;
using ApiAggregatorServices;

namespace ApiAggregator
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IOpenWeatherService, OpenWeatherService>();
            
            return services;
        }
    }
}
