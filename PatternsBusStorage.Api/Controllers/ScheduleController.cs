using Microsoft.AspNetCore.Mvc;
using PatternsBusStorage.Api.DTOs.Schedule;
using PatternsBusStorage.Bll.Observer;
using PatternsBusStorage.Bll.Services;
using PatternsBusStorage.Domain.Aggregates;

namespace PatternsBusStorage.Api.Controllers;

[ApiController]
[Route(ApiRoutes.BaseRoute)]
public class ScheduleController : ControllerBase
{

    private readonly ScheduleService _scheduleService;

    public ScheduleController(ScheduleService scheduleService)
    {
        _scheduleService = scheduleService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllSchedules()
    {
        var schedules = await _scheduleService.GetAllSchedules();
        return Ok(schedules.ToList());
    }

    [HttpPost]
    public async Task<IActionResult> AddSchedule([FromBody] ScheduleCreate schedule)
    {
        await _scheduleService.AddSchedule(new Schedule{BusId = schedule.BusId, RouteId = schedule.RouteId, StopId = schedule.StopId, DepartureTime = schedule.DepartureTime, ArrivalTime = schedule.ArrivalTime});
        return Ok();
    }

    [HttpPatch]
    [Route(ApiRoutes.Schedule.IdRoute)]
    public async Task<IActionResult> UpdateSchedule([FromBody] ScheduleUpdate schedule, int id)
    {
        // Create a specific subject for bus schedules
        var busScheduleSubject = new ScheduleSubject();

        // Create observers for bus schedules
        var busScheduleObserver1 = new ScheduleObserver("BusScheduleObserver1");
        var busScheduleObserver2 = new ScheduleObserver("BusScheduleObserver2");

        // Register observers with the specific subject
        busScheduleSubject.Attach(busScheduleObserver1);
        busScheduleSubject.Attach(busScheduleObserver2);

        var res = await _scheduleService
            .UpdateSchedule(new Schedule{ScheduleId = id, BusId = schedule.BusId,
                StopId = schedule.StopId, DepartureTime = schedule.DepartureTime,
                ArrivalTime = schedule.ArrivalTime}, busScheduleSubject);

        return Ok();
    }

    [HttpGet]
    [Route(ApiRoutes.Schedule.IdRoute)]
    public async Task<IActionResult> GetScheduleById(int id)
    {
        var res = await _scheduleService.GetScheduleById(id);
        return Ok(res);
    }
}