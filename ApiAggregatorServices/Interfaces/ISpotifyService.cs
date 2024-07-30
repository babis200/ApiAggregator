using ApiAggregatorModels.Spotify;
using Type = ApiAggregatorClients.Refit.Type;


namespace ApiAggregatorServices.Interfaces
{
    public interface ISpotifyService
    {
        Task<SpotifySearchResponse> SearchAsync(
            string keywords, 
            IEnumerable<Type> types, 
            string market); //The 2-letter ISO 3166-1 alpha-2 country code

    }
}
