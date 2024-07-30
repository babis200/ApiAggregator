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
        private readonly NewsApiConfig _config;

        public NewsApiService(INewsApi newsApi, NewsApiConfig config)
        {
            _config = config;
            _newsApi = newsApi;
        }

        public async Task<ApiResponse> GetEverythingAsync(string? keyword)
        {
            return await _newsApi.GetEverythingAsync(keyword, _config.ApiKey);
        }

        public async Task<ApiResponse> GetTopHeadlinesAsync(string country,Categories? category, string? keywords)
        {
            return await _newsApi.GetTopHeadlinesAsync(country, category, keywords, _config.ApiKey);
        }

    }
}
