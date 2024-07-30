using ApiAggregatorModels.NewsApi;
using NewsAPI.Constants;

namespace ApiAggregatorServices.Interfaces
{
    public interface INewsApiService
    {
        Task<ApiResponse> GetTopHeadlinesAsync(string? country, Categories? category, string keywords);
        Task<ApiResponse> GetEverythingAsync(string? keyword);

    }
}
