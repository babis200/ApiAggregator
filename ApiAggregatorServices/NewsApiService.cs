using ApiAggregatorConfiguration;
using ApiAggregatorConstants.NewsApi;
using ApiAggregatorControllers.Refit.NewsApi;
using ApiAggregatorModels.NewsApi;
using ApiAggregatorModels.OpenWeather;
using ApiAggregatorServices.Interfaces;
using NewsAPI.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiAggregatorServices
{
    public class NewsApiService : INewsApiServiceInterface
    {
        private readonly INewsApi _newsApi;
        private readonly NewsApiConfig _config;

        public NewsApiService(INewsApi newsApi, NewsApiConfig config)
        {
            _config = config;
            _newsApi = newsApi;
        }
        public async Task<ApiResponse> GetEverythingAsync(string keyword)
        {
            return await _newsApi.GetEverythingAsync(city, _config.ApiKey);
        }

        public async Task<ApiResponse> GetTopHeadlinesAsync(string country, Categories category, string keywords)
        {
            return await _newsApi.GetTopHeadlinesAsync(country, category, keywords, _config.ApiKey);
        }

    }
}
