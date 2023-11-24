using Microsoft.AspNetCore.Mvc;
using PatternsBusStorage.Api.DTOs.Bus;
using PatternsBusStorage.Bll.Repositories;
using PatternsBusStorage.Bll.Services;
using PatternsBusStorage.Domain.Aggregates;
using PatternsBusStorage.Domain.Mementos.Bus;

namespace PatternsBusStorage.Api.Controllers;

[ApiController]
[Route(ApiRoutes.BaseRoute)]
public class BusController : ControllerBase
{
        private readonly BusService _busService;

        public BusController(BusService busService)
        {
                _busService = busService;
        }
    
        [HttpGet]
        public async Task<IActionResult> GetAllBuses()
        {
                var buses = await _busService.GetAllBuses();
                return Ok(buses.ToList());
        }

        [HttpPost]
        public async Task<IActionResult> AddBus([FromBody] BusCreate bus)
        {
                Bus b = new Bus.BusBuilder(bus.BusNumber, bus.Status)
                        .SetModel(bus.Model)
                        .SetManufacturingYear(bus.ManufacturingYear)
                        .SetCapacity(bus.Capacity)
                        .Build();
                await _busService.AddBus(b);

                return Ok();
        }

        [HttpPatch]
        [Route(ApiRoutes.Bus.IdRoute)]
        public async Task<IActionResult> UpdateBus([FromBody] BusUpdate bus, int id)
        {
                Bus b = new Bus.BusBuilder(bus.BusNumber, bus.Status)
                        .SetModel(bus.Model)
                        .SetManufacturingYear(bus.ManufacturingYear)
                        .SetCapacity(bus.Capacity)
                        .Build();

                var res = await _busService.UpdateBus(b);
        
                return Ok();
        }
        
        [HttpPatch]
        [Route(ApiRoutes.Bus.NumberRoute)]
        public async Task<IActionResult> UpdateBusByNumber([FromBody] BusUpdateByNumber bus, string number)
        {
                Bus b = new Bus.BusBuilder(number, bus.Status)
                        .SetModel(bus.Model)
                        .SetManufacturingYear(bus.ManufacturingYear)
                        .SetCapacity(bus.Capacity)
                        .Build();
                
                var res = await _busService.UpdateBusByNumber(b);
                
                return Ok();
        }
        
        [HttpGet]
        [Route(ApiRoutes.Bus.IdRoute)]
        public async Task<IActionResult> GetBusById(int id)
        {
                var res = await _busService.GetBusById(id);
                return Ok(res);
        }
        
        [HttpGet]
        [Route(ApiRoutes.Bus.NumberRoute)]
        public async Task<IActionResult> GetBusByNumber([FromRoute]string number)
        {
                var res = await _busService.GetBusByNumber(number);
                return Ok(res);
        }


        [HttpPatch]
        [Route(ApiRoutes.Bus.MementoTest)]
        public async Task<IActionResult> TestMementoByBusId(int id)
        {
                var res = await _busService.TestMemento(id);
                return Ok(res);
        }
        
        
}