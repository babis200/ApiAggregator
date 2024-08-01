using ApiAggregatorModels.TravelInfo;
using ApiAggregatorServices.Interfaces;

namespace ApiAggregatorServices
{
    public class TravelCompanionService : ITravelCompanionService
    {
        private readonly ITriviaService _triviaService;
        private readonly INewsApiService _newsApiService;
        private readonly IOpenWeatherService _openWeatherService;

        public TravelCompanionService(
            ITriviaService triviaService,
            INewsApiService newsApiService,
            IOpenWeatherService openWeatherService
            )
        {
            _triviaService = triviaService;
            _newsApiService = newsApiService;
            _openWeatherService = openWeatherService;
        }

        public async Task<TravelInfo> GetTravelInfoAsync(string location)
        {
            try
            {
                //Get News
                var news = await _newsApiService.GetTopHeadlinesAsync(location, null, "News");

                //Get Trivia Fact
                var trivia = await _triviaService.GetTrivia(1);

                //Get Weather
                var weather = await _openWeatherService.GetWeatherForCityAsync(location);

                return new TravelInfo()
                {
                    LocalNews = news.Articles.Select(x => new NewsArticle()
                    {
                        Title = x.Title,
                        Url = x.Url,
                        Description = x.Description,
                    }).ToList(),
                    DestinationWeather = new()
                    {
                        Location = location,
                        Temperature = weather.Main.Temp,
                        Humidity = weather.Main.Humidity
                    },
                    TriviaFact = trivia
                };

            }
            catch (Exception e)
            {
                //TODO
                //return BadRequest("An error occurred while fetching news data.");

                throw;
            }
        }
    }
}
