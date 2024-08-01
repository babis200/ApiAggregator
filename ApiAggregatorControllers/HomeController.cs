using ApiAggregatorServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace TravelCompanionApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly TravelCompanionService _travelCompanionService;

        public HomeController(TravelCompanionService travelCompanionService)
        {
            _travelCompanionService = travelCompanionService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GetTravelInfo(string location)
        {
            var travelInfo = await _travelCompanionService.GetTravelInfoAsync(location);
            return View("TravelInfo", travelInfo);
        }
    }
}
