using PatternsBusStorage.Domain.Aggregates;

namespace PatternsBusStorage.Bll.Observer;

public interface IScheduleObserver : IObserver<Schedule>
{
}