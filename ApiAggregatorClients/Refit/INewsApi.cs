using Refit;
using ApiAggregatorModels.NewsApi;
using NewsAPI.Constants;

namespace ApiAggregatorClients.Refit
{
    [Headers("Authorization: Basic")]
    public interface INewsApi
    {
        [Get("/top-headlines")]
        Task<NewsApiResponse> GetTopHeadlinesAsync(
            string country, //The 2-letter ISO 3166-1
            Categories? category,
            string? keywords
            );

        [Get("/everything")]
        Task<NewsApiResponse> GetEverythingAsync(
            string? keywords
            );

    }

}
