using PatternsBusStorage.Domain.Aggregates;

namespace PatternsBusStorage.Bll.Observer;

public class ScheduleSubject : IScheduleSubject
{
    private readonly List<IObserver<Schedule>> _observers = new();
    private Schedule currentSchedule;
    
    public void Attach(IObserver<Schedule> observer)
    {
        _observers.Add(observer);
        Console.WriteLine("Subject: Attached an observer.");
    }

    public void Detach(IObserver<Schedule> observer)
    {
        _observers.Remove(observer);
        Console.WriteLine("Subject: Detached an observer.");
    }

    public void Notify(Schedule updatedSchedule)
    {
        _observers.ForEach(o =>
        {
            o.Update(updatedSchedule);
        });
    }
    
    public void UpdateSchedule(Schedule newSchedule)
    {
        currentSchedule = newSchedule;
        Notify(currentSchedule);
    }
}