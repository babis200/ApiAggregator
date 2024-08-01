using ApiAggregatorModels.TravelInfo;

namespace ApiAggregatorServices.Interfaces
{
    public interface ITravelCompanionService
    {
        Task<TravelInfo> GetTravelInfoAsync(string location);
    }
}
