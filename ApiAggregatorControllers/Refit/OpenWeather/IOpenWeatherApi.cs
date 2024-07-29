using ApiAggregatorModels.OpenWeather;
using Refit;

namespace ApiAggregatorControllers.Refit.OpenWeather
{
    public interface IOpenWeatherApi
    {
        [Get("")]
        Task<WeatherModel> GetWeatherAsync(
        [AliasAs("q")] string city,
        [AliasAs("appid")] string apiKey/*,
        [AliasAs("units")] string units = "metric"*/);

        [Get("")]
        Task<WeatherModel> GetWeatherForZipCodeAsync(
            [AliasAs("q")] string city,
            [AliasAs("appid")] string apiKey,
            [AliasAs("units")] string units = "metric");

    }
}
