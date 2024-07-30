using ApiAggregatorServices.Interfaces;
using Microsoft.AspNetCore.Mvc;
using NewsAPI.Constants;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Refit;

namespace ApiAggregatorControllers.NewsApi
{
    [ApiController]
    [Route("[controller]")]
    public class NewsApiController : ControllerBase
    {
        private readonly INewsApiService _newsApiService;

        public NewsApiController(INewsApiService newsApiService)
        {
            _newsApiService = newsApiService;
        }

        [HttpGet("top-headlines")]
        public async Task<IActionResult> GetWeatherForCityAsync(
            string country, Categories categories, string keywords)
        {
            try
            {
                var response = await _newsApiService.GetTopHeadlinesAsync(country, categories, keywords);
                return Ok(response);
            }
            catch (ApiException e)
            {
                return StatusCode((int)e.StatusCode, "Error fetching news data.");
            }
            catch (Exception e)
            {
                return BadRequest("An error occurred while fetching news data.");
            }
        }

        [HttpGet("everything")]
        public async Task<IActionResult> GetEverythingAsync(
            string? keywords)
        {
            try
            {
                var response = await _newsApiService.GetEverythingAsync(keywords);
                return Ok(response);
            }
            catch (ApiException e)
            {
                return StatusCode((int)e.StatusCode, "Error fetching news data.");
            }
            catch (Exception e)
            {
                return BadRequest("An error occurred while fetching news data.");
            }
        }
    }
}
