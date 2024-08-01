using Newtonsoft.Json;
using Refit;

namespace ApiAggregatorClients.Refit
{
    public interface ISpotifyLoginApi
    {
        [Post("/api/token")]
        [Headers("Content-Type: application/x-www-form-urlencoded")]
        Task<TokenResponse> GetAccessTokenAsync(
            [Header("Authorization")] string authorization,
            [AliasAs("grant_type")] string grantType = "client_credentials"
        );
    }

    public class TokenResponse
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("token_type")]
        public string TokenType { get; set; }

        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }
    }
}
