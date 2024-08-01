using ApiAggregatorConfiguration;
using System.Net.Http.Headers;
using System.Text;

namespace ApiAggregatorClients.Refit
{
    public class SpotifyAuthDelegatingHandler : DelegatingHandler
    {
        private string _authToken;
        private int _expiresIn;

        private readonly ISpotifyLoginApi _loginApi;
        private readonly SpotifyConfig _config;

        public SpotifyAuthDelegatingHandler(ISpotifyLoginApi loginApi, SpotifyConfig config)
        {
            _loginApi = loginApi;
            _config = config;
        }

        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken cancellationToken
            )
        {
            if (DateTime.UtcNow.AddMinutes(1) > DateTime.UtcNow.AddSeconds(_expiresIn))
            {
                var encodedString = EncodeToBase64(_config.ClientId + ":" + _config.ClientSecret);

                var response = await _loginApi.GetAccessTokenAsync("Basic " + encodedString);

                _authToken = response.AccessToken;
                _expiresIn = response.ExpiresIn;
            }

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _authToken);
            return await base.SendAsync(request, cancellationToken);
        }

        static string EncodeToBase64(string clientId)
        {
            byte[] byteArray = Encoding.UTF8.GetBytes(clientId);
            string base64Encoded = Convert.ToBase64String(byteArray);

            return base64Encoded;
        }
    }
}
