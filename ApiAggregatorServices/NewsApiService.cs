using ApiAggregatorClients.Refit;
using ApiAggregatorConfiguration;
using ApiAggregatorModels.NewsApi;
using ApiAggregatorServices.Interfaces;
using NewsAPI.Constants;

namespace ApiAggregatorServices
{
    public class NewsApiService : INewsApiService
    {
        private readonly INewsApi _newsApi;

        public NewsApiService(INewsApi newsApi)
        {
            _newsApi = newsApi;
        }

        public async Task<NewsApiResponse> GetEverythingAsync(string? keyword)
        {
            return await _newsApi.GetEverythingAsync(keyword);
        }

        public async Task<NewsApiResponse> GetTopHeadlinesAsync(string country, Categories? category, string? keywords)
        {
            return await _newsApi.GetTopHeadlinesAsync(country, category, keywords);
        }

    }
}
