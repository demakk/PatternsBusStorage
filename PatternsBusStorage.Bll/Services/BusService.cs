using Microsoft.Extensions.Configuration;
using PatternsBusStorage.Application.Repositories;
using PatternsBusStorage.Bll.Factories;
using PatternsBusStorage.Bll.Repositories;
using PatternsBusStorage.Dal;
using PatternsBusStorage.Domain.Aggregates;
using PatternsBusStorage.Domain.Mementos.Bus;

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

    public async Task<Bus> TestMemento(int id)
    {
        var bus  = await _busRepository.GetById(id);
        
        // Instantiate the BusCareTaker
        var busCareTaker = new BusCareTaker();

        // Save the initial state to the caretaker
        busCareTaker.AddMemento(bus.SaveToMemento());
        
        Console.WriteLine(bus.ToString());
        
        // Modify the bus entity
        bus.Model = "New Model";
        bus.Capacity = 50;

        Console.WriteLine(bus.ToString());

        // Save the modified state to the caretaker
        busCareTaker.AddMemento(bus.SaveToMemento());

        // Undo the last change
        bus.RestoreFromMemento(busCareTaker.GetMemento(0));

        Console.WriteLine(bus.ToString());
        return bus;
    }
}