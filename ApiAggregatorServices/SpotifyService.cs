using ApiAggregatorClients.Refit;
using ApiAggregatorModels.Spotify;
using ApiAggregatorServices.Interfaces;
using Type = ApiAggregatorClients.Refit.Type;

namespace ApiAggregatorServices
{
    public class SpotifyService : ISpotifyService
    {
        private readonly ISpotifyApi _spotifyApi;

        public SpotifyService(ISpotifyApi spotifyApi)
        {
            _spotifyApi = spotifyApi;
        }

        public async Task<SpotifySearchResponse> SearchAsync(
            string keywords, IEnumerable<Type> types, string? market)
        {
            var stringTypes = String.Join(',', types);
            return await _spotifyApi.SearchForItemAsync(keywords, stringTypes, market);
        }
    }
}
