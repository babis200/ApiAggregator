using ApiAggregatorServices.Interfaces;
using ApiAggregatorServices;

namespace ApiAggregator
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddTransient<IOpenWeatherService, OpenWeatherService>();
            services.AddTransient<INewsApiService, NewsApiService>();
            services.AddTransient<ISpotifyService, SpotifyService>();
            services.AddTransient<ITriviaService, TriviaService>();
            services.AddTransient<ITravelCompanionService, TravelCompanionService>();

            return services;
        }
    }
}
