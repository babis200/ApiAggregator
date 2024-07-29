using ApiAggregatorConstants.NewsApi;
using ApiAggregatorModels.NewsApi;

namespace ApiAggregatorServices.Interfaces
{
    public interface INewsApiServiceInterface
    {
        Task<ApiResponse> GetTopHeadlinesAsync(string country, Category category, string keywords);
        Task<ApiResponse> GetEverythingAsync(string keyword);

    }
}
