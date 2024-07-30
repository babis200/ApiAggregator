using Refit;
using ApiAggregatorServices.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Type = ApiAggregatorClients.Refit.Type;

namespace ApiAggregatorControllers.Spotify
{
    [ApiController]
    [Route("[controller]/spotify")]
    public class SpotifyController : ControllerBase
    {
        private readonly ISpotifyService _spotifyService;

        public SpotifyController(ISpotifyService spotifyService)
        {
            _spotifyService = spotifyService;
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchAsync(string keywords, IEnumerable<Type> types, string market)
        {
            try
            {
                var result = await _spotifyService.SearchAsync(keywords, types, market);
                return Ok(result);
            }
            catch (ApiException e)
            {
                return StatusCode((int)e.StatusCode, "Error fetching spotify data.");
            }
            catch (Exception e)
            {
                return BadRequest("An error occurred while fetching spotify data.");
            }
        }
    }
}
