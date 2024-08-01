using ApiAggregatorServices.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiAggregator
{
    [ApiController]
    [Route("Home")]
    public class HomeController : Controller
    {
        private readonly ITravelCompanionService _travelCompanionService;

        public HomeController(ITravelCompanionService travelCompanionService)
        {
            _travelCompanionService = travelCompanionService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            //TODO find index
            return View("Index");
        }

        [HttpPost]
        public async Task<IActionResult> GetTravelInfo(string location)
        {
            var travelInfo = await _travelCompanionService.GetTravelInfoAsync(location);
            return View("TravelInfo", travelInfo);
        }
    }
}
