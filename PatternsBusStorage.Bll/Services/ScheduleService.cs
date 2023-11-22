using PatternsBusStorage.Application.Repositories;
using PatternsBusStorage.Bll.Repositories;
using PatternsBusStorage.Domain.Aggregates;

namespace PatternsBusStorage.Bll.Services;

public class ScheduleService
{
    private readonly ScheduleRepository _scheduleRepository;

    public ScheduleService(ScheduleRepository scheduleRepository)
    {
        _scheduleRepository = scheduleRepository;
    }
    
    public async Task<Schedule> AddSchedule(Schedule schedule)
    {
        await _scheduleRepository.Add(schedule);
        return new Schedule();
    }

    public async Task<IEnumerable<Schedule>> GetAllSchedules()
    {
        return await _scheduleRepository.GetAll();
    }

    public async Task<Schedule> UpdateSchedule(Schedule schedule)
    {
        return await _scheduleRepository.Update(schedule);
    }

    public async Task<Schedule> GetScheduleById(int id)
    {
        return await _scheduleRepository.GetById(id);
    }
}