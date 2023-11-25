using PatternsBusStorage.Application.Repositories;
using PatternsBusStorage.Bll.Repositories;
using PatternsBusStorage.Domain.Aggregates;

namespace PatternsBusStorage.Bll.Services;

public class BusStopService
{
    private readonly BusStopRepository _busStopRepository;

    public BusStopService(BusStopRepository busStopRepository)
    {
        _busStopRepository = busStopRepository;
    }

    public async Task<BusStop> AddBusStop(BusStop busStop)
    {
        await _busStopRepository.Add(busStop);
        return new BusStop();
    }

    public async Task<IEnumerable<BusStop>> GetAllBusStops()
    {
        return await _busStopRepository.GetAll();
    }

    public async Task<BusStop> UpdateBusStop(BusStop busStop, int id)
    {
        return await _busStopRepository.Update(busStop, id);
    }

    public async Task<BusStop> GetBusStopById(int id)
    {
        return await _busStopRepository.GetById(id);
    }
}