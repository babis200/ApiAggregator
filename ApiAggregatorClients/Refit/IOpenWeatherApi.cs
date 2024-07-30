using ApiAggregatorModels.OpenWeather;
using Refit;

namespace ApiAggregatorClients.Refit
{
    public interface IOpenWeatherApi
    {
        [Get("")]
        Task<WeatherModel> GetWeatherForCityAsync(
        [AliasAs("q")] string city,     //City is based on ISO 3166-2
        [AliasAs("appid")] string apiKey,
        [AliasAs("units")] string units = "metric");

        [Get("")]
        Task<WeatherModel> GetWeatherForZipCodeAsync(
            [AliasAs("zip")] string zipCode,
            [AliasAs("appid")] string apiKey,
            [AliasAs("units")] string units = "metric");

    }
}
