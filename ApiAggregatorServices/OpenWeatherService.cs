using ApiAggregatorClients.Refit;
using ApiAggregatorConfiguration;
using ApiAggregatorModels.OpenWeather;
using ApiAggregatorServices.Interfaces;

namespace ApiAggregatorServices
{
    public class OpenWeatherService : IOpenWeatherService
    {
        private readonly IOpenWeatherApi _openWeatherApi;
        private readonly OpenWeatherConfig _config;


        public OpenWeatherService(IOpenWeatherApi openWeatherApi,
            OpenWeatherConfig config
            )
        {
            _openWeatherApi = openWeatherApi;
            _config = config;
        }

        public async Task<WeatherModel> GetWeatherForCityAsync(string city)
        {
            return await _openWeatherApi.GetWeatherForCityAsync(city, _config.ApiKey);
        }

        public async Task<WeatherModel> GetWeatherForZipCodeAsync(string zipCode)
        {
            return await _openWeatherApi.GetWeatherForZipCodeAsync(zipCode, _config.ApiKey);
        }
    }
}
