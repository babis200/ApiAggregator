using ApiAggregatorClients.Refit;
using ApiAggregatorModels.Trivia;
using ApiAggregatorServices.Interfaces;

namespace ApiAggregatorServices
{
    public class TriviaService : ITriviaService
    {
        private readonly ITriviaApi _triviaApi;

        public TriviaService(ITriviaApi triviaApi)
        {
            _triviaApi = triviaApi;
        }

        public async Task<TriviaResponse> GetTrivia(int amount)
        {
            try
            {
                var response = await _triviaApi.GetTriviaAsync(amount);

                return response;
            }
            catch (Exception e )
            {
                throw;
            }
        }
    }
}
