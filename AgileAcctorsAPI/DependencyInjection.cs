using ApiAggregatorServices.Interfaces;
using ApiAggregatorServices;

namespace ApiAggregator
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            //TODO - probably need to make these scoped in order to cache results
            services.AddTransient<IOpenWeatherService, OpenWeatherService>();
            services.AddTransient<INewsApiService, NewsApiService>();
            
            return services;
        }
    }
}
