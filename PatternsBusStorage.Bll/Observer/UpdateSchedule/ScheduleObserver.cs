using PatternsBusStorage.Domain.Aggregates;

namespace PatternsBusStorage.Bll.Observer;

public class ScheduleObserver : IScheduleObserver
{
    private readonly string _observerName;
    public ScheduleObserver(string name)
    {
        _observerName = name;
    }
    public void Update(Schedule updatedSchedule)
    {
        Console.WriteLine($"Observer {_observerName} received an update." +
                          $" New schedule: {updatedSchedule.DepartureTime} -" +
                          $" {updatedSchedule.ArrivalTime}");
    }
}