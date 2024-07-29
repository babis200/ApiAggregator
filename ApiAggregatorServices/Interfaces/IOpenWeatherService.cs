using ApiAggregatorModels.OpenWeather;

namespace ApiAggregatorServices.Interfaces;

public interface IOpenWeatherService
{
    Task<WeatherModel> GetWeatherAsync(string city);
    Task<WeatherModel> GetWeatherForZipCodeAsync(string zipCode);

}
