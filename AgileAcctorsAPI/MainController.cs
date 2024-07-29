using ApiAggregatorModels.OpenWeather;
using Microsoft.AspNetCore.Mvc;
using ApiAggregatorServices.Interfaces;

namespace ApiAggregatorControllers
{
    [ApiController]
    [Route("[controller]")]
    public class MainController : ControllerBase
    {

        private readonly ILogger<MainController> _logger;
        private readonly IOpenWeatherService _openWeatherService;

        public MainController(ILogger<MainController> logger, IOpenWeatherService openWeatherService)
        {
            _logger = logger;
            _openWeatherService = openWeatherService;
        }

        [HttpGet(Name = "GetWeatherForCity")]
        public async Task<WeatherModel> GetAsync(string city) //TODO - Replace WeatherModel with ViewModel
        {
            return await _openWeatherService.GetWeatherAsync(city);
        }
    }
}
