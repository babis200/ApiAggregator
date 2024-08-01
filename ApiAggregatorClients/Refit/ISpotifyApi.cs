using ApiAggregatorModels.Spotify;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Refit;

namespace ApiAggregatorClients.Refit
{
    public interface ISpotifyApi
    {
        [Get("/search")]
        Task<SpotifySearchResponse> SearchForItemAsync(
            [AliasAs("q")] string keyword,
            string types,
            string? market,  //The 2-letter ISO 3166-1 alpha-2 country code
            int limit = 5
            );
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum Type
    {
        //TODO - move where it should be
        album,
        artist,
        playlist,
        track,
        show,
        episode,
        audiobook
    }
}
