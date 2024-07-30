using ApiAggregatorModels.OpenWeather;

namespace ApiAggregatorServices.Interfaces;

public interface IOpenWeatherService
{
    Task<WeatherModel> GetWeatherForCityAsync(string city);
    Task<WeatherModel> GetWeatherForZipCodeAsync(string zipCode);

}
