using ApiAggregatorModels.Trivia;
using Refit;

namespace ApiAggregatorClients.Refit
{
    public interface ITriviaApi
    {
        [Get("")]
        Task<TriviaResponse> GetTriviaAsync(int amount = 1);
    }
}
