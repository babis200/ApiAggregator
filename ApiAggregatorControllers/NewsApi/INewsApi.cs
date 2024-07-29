using Refit;
using ApiAggregatorModels.NewsApi;
using NewsAPI.Constants;

namespace ApiAggregatorControllers.NewsApi
{
    public interface INewsApi
    {
        [Get("top-headlines")]
        Task<ApiResponse> GetTopHeadlinesAsync(
            string country, //The 2-letter ISO 3166-1
            Categories category,
            string keywords,
            string apiKey
            );

        [Get("everything")]
        Task<ApiResponse> GetEverythingAsync(
            string keywords,
            Categories category,
            string apiKey
            );

    }

}
