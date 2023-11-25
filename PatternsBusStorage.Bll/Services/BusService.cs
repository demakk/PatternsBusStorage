using Microsoft.Extensions.Configuration;
using PatternsBusStorage.Application.Repositories;
using PatternsBusStorage.Bll.DTOs;
using PatternsBusStorage.Bll.Factories;
using PatternsBusStorage.Bll.Repositories;
using PatternsBusStorage.Bll.Repositories.Proxy;
using PatternsBusStorage.Dal;
using PatternsBusStorage.Domain.Aggregates;
using PatternsBusStorage.Domain.Mementos.Bus;

namespace PatternsBusStorage.Bll.Services;

public class BusService
{
    private readonly BusProxyRepository _busProxyRepository;

    public BusService(BusProxyRepository busProxyRepository)
    {
        _busProxyRepository = busProxyRepository;
    }

    public async Task<Bus> AddBus(Bus bus, string userRole)
    {
        await _busProxyRepository.Add(bus, userRole);
        return new Bus();
    }

    public async Task<IEnumerable<Bus>> GetAllBuses()
    {
        return await _busProxyRepository.GetAll();
    }

    public async Task<Bus> UpdateBus(Bus bus, string userRole, int id)
    {
        return await _busProxyRepository.Update(bus, userRole,id);
    }

    public async Task<Bus> UpdateBusByNumber(Bus bus, string userRole)
    {
        return await _busProxyRepository.UpdateBusByNumber(bus, userRole);
    }

    public async Task<Bus> GetBusById(int id)
    {
        return await _busProxyRepository.GetById(id);
    }

    public async Task<Bus> GetBusByNumber(string number)
    {
        return await _busProxyRepository.GetBusByNumber(number);
    }

    public async Task<Bus> TestMemento(int id)
    {
        var bus  = await _busProxyRepository.GetById(id);
        
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