using ApiAggregatorModels.Trivia;

namespace ApiAggregatorModels.TravelInfo;

public class TravelInfo
{
    public List<NewsArticle> LocalNews { get; set; }
    public WeatherForecast DestinationWeather { get; set; }
    public TriviaResponse TriviaFact { get; set; }

}
