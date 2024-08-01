using ApiAggregatorModels.NewsApi;
using NewsAPI.Constants;

namespace ApiAggregatorServices.Interfaces
{
    public interface INewsApiService
    {
        Task<NewsApiResponse> GetTopHeadlinesAsync(string? country, Categories? category, string keywords);
        Task<NewsApiResponse> GetEverythingAsync(string? keyword);

    }
}
