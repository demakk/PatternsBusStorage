using Microsoft.Extensions.Configuration;
using PatternsBusStorage.Application.Repositories;
using PatternsBusStorage.Bll.Factories;
using PatternsBusStorage.Bll.Repositories;
using PatternsBusStorage.Dal;
using PatternsBusStorage.Domain.Aggregates;

namespace PatternsBusStorage.Bll.Services;

public class BusService
{
    private readonly IBusRepository _busRepository;

    public BusService(IConfiguration configuration)
    {
        var sql = new MssqlDbFactory(configuration);
        _busRepository = sql.CreateBusRepository();
    }

    public async Task<Bus> AddBus(Bus bus)
    {
        await _busRepository.Add(bus);
        return new Bus();
    }
    
    public async Task<IEnumerable<Bus>> GetAllBuses()
    {
        return await _busRepository.GetAll();
    }

    public async Task<Bus> UpdateBus(Bus bus)
    {
        return await _busRepository.Update(bus);
    }
    
    public async Task<Bus> UpdateBusByNumber(Bus bus)
    {
        return await _busRepository.UpdateBusByNumber(bus);
    }

    public async Task<Bus> GetBusById(int id)
    {
        return await _busRepository.GetById(id);
    }
    
    public async Task<Bus> GetBusByNumber(string number)
    {
        return await _busRepository.GetBusByNumber(number);
    }
}