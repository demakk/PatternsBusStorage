using Microsoft.AspNetCore.Mvc;
using PatternsBusStorage.Api.DTOs.Bus;
using PatternsBusStorage.Bll.Services;
using PatternsBusStorage.Domain.Aggregates;

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
        public async Task<IActionResult> AddBus([FromBody] BusCreate bus, string role)
        {
                Bus b = new Bus.BusBuilder(bus.BusNumber, bus.Status)
                        .SetModel(bus.Model)
                        .SetManufacturingYear(bus.ManufacturingYear)
                        .SetCapacity(bus.Capacity)
                        .Build();
                await _busService.AddBus(b, role);

                return Ok();
        }

        [HttpPatch]
        [Route(ApiRoutes.Bus.IdRoute)]
        public async Task<IActionResult> UpdateBus([FromBody] BusUpdate bus, int id, string role)
        {
                Bus b = new Bus.BusBuilder(bus.BusNumber, bus.Status)
                        .SetModel(bus.Model)
                        .SetManufacturingYear(bus.ManufacturingYear)
                        .SetCapacity(bus.Capacity)
                        .Build();

                var res = await _busService.UpdateBus(b, role, id);
        
                return Ok();
        }
        
        [HttpPatch]
        [Route(ApiRoutes.Bus.NumberRoute)]
        public async Task<IActionResult> UpdateBusByNumber([FromBody] BusUpdateByNumber bus, string number, string role)
        {
                Bus b = new Bus.BusBuilder(number, bus.Status)
                        .SetModel(bus.Model)
                        .SetManufacturingYear(bus.ManufacturingYear)
                        .SetCapacity(bus.Capacity)
                        .Build();
                
                var res = await _busService.UpdateBusByNumber(b, role);
                
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