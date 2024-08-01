using ApiAggregatorModels.Trivia;

namespace ApiAggregatorServices.Interfaces
{
    public interface ITriviaService
    {
        Task<TriviaResponse> GetTrivia(int amount);
    }
}
