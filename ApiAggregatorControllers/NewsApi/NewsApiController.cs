using ApiAggregatorConfiguration;
using Microsoft.AspNetCore.Mvc;
using NewsAPI.Constants;
using Refit;

namespace ApiAggregatorControllers.NewsApi
{
    [ApiController]
    [Route("api/[controller]")]
    public class NewsApiController : ControllerBase
    {
        private readonly INewsApi _newsApi;
        private readonly NewsApiConfig _config;

        public NewsApiController(INewsApi NewsApi, NewsApiConfig config)
        {
            _newsApi = NewsApi;
            _config = config;
        }

        [HttpGet("{top-headlines}")]
        public async Task<IActionResult> GetWeatherForCityAsync(
            string country, Categories categories, string keywords)
        {
            try
            {
                var response = await _newsApi.GetTopHeadlinesAsync(country, categories, keywords, _config.ApiKey);
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

        [HttpGet("{everything}")]
        public async Task<IActionResult> GetEverythingAsync(string keywords, Categories categories)
        {
            try
            {
                var response = await _newsApi.GetEverythingAsync(keywords, categories, _config.ApiKey);
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
