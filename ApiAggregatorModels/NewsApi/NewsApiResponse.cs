using NewsAPI.Constants;
using NewsAPI.Models;

namespace ApiAggregatorModels.NewsApi
{
    public class NewsApiResponse
    {
        public Statuses Status { get; set; }
        public ErrorCodes? Code { get; set; }
        public string Message { get; set; }
        public List<Article> Articles { get; set; }
        public int TotalResults { get; set; }
    }
}
