using PatternsBusStorage.Application.Repositories;
using PatternsBusStorage.Bll.Repositories;
using PatternsBusStorage.Domain.Aggregates;

namespace PatternsBusStorage.Bll.Services;

public class BusRouteService
{
    private readonly BusRouteRepository _busRouteRepository;

    public BusRouteService(BusRouteRepository busRouteRepository)
    {
        _busRouteRepository = busRouteRepository;
    }

    public async Task<BusRoute> AddBusRoute(BusRoute busRoute)
    {
        await _busRouteRepository.Add(busRoute);
        return new BusRoute();
    }

    public async Task<IEnumerable<BusRoute>> GetAllBusRoutes()
    {
        return await _busRouteRepository.GetAll();
    }

    public async Task<BusRoute> UpdateBusRoute(BusRoute busRoute)
    {
        return await _busRouteRepository.Update(busRoute);
    }

    public async Task<BusRoute> GetBusRouteById(int id)
    {
        return await _busRouteRepository.GetById(id);
    }
    
}

