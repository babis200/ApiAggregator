using Refit;
using Microsoft.AspNetCore.Mvc;
using ApiAggregatorServices.Interfaces;

namespace ApiAggregatorControllers.OpenWeather
{
    [ApiController]
    [Route("[controller]/openWeather")]
    public class OpenWeatherController : ControllerBase
    {
        private readonly IOpenWeatherService _openWeatherService;

        public OpenWeatherController(IOpenWeatherService openWeatherService)
        {
            _openWeatherService = openWeatherService;
        }

        [HttpGet("city")]
        public async Task<IActionResult> GetWeatherForCityAsync(string city)
        {
            try
            {
                var weatherData = await _openWeatherService.GetWeatherForCityAsync(city);
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

        [HttpGet("zipCode")]
        public async Task<IActionResult> GetWeatherForZipCodeAsync(string zipCode)
        {
            try
            {
                var weatherData = await _openWeatherService.GetWeatherForZipCodeAsync(zipCode);
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
