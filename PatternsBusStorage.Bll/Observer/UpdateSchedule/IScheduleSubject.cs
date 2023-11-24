using PatternsBusStorage.Domain.Aggregates;

namespace PatternsBusStorage.Bll.Observer;

public interface IScheduleSubject : ISubject<Schedule>
{
    void UpdateSchedule(Schedule updatedSchedule);
}