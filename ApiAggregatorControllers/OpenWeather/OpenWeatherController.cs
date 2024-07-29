using Refit;
using ApiAggregatorConfiguration;
using Microsoft.AspNetCore.Mvc;

namespace ApiAggregatorControllers.OpenWeather
{
    [ApiController]
    [Route("api/[controller]")]
    public class OpenWeatherController : ControllerBase
    {
        private readonly IOpenWeatherApi _openWeatherApi;
        private readonly OpenWeatherConfig _config;

        public OpenWeatherController(IOpenWeatherApi openWeatherApi, OpenWeatherConfig config)
        {
            _openWeatherApi = openWeatherApi;
            _config = config;
        }

        [HttpGet("{city}")]
        public async Task<IActionResult> GetWeatherForCityAsync(string city)
        {
            try
            {
                var weatherData = await _openWeatherApi.GetWeatherForCityAsync(city, _config.ApiKey);
                return Ok(weatherData);
            }
            catch (ApiException e)
            {
                return StatusCode((int)e.StatusCode, "Error fetching weather data.");
            }
            catch (Exception e)
            {
                return BadRequest("An error occurred while fetching weather data.");
            }
        }

        [HttpGet("{zipCode}")]
        public async Task<IActionResult> GetWeatherForZipCodeAsync(string zipCode)
        {
            try
            {
                var weatherData = await _openWeatherApi.GetWeatherForZipCodeAsync(zipCode, _config.ApiKey);
                return Ok(weatherData);
            }
            catch (ApiException e)
            {
                return StatusCode((int)e.StatusCode, "Error fetching weather data.");
            }
            catch (Exception e)
            {
                return BadRequest("An error occurred while fetching weather data.");
            }
        }
    }
}
