namespace PatternsBusStorage.Api.DTOs.Schedule;

public class ScheduleCreate
{
    public int BusId { get; set; }
    public int RouteId { get; set; }
    public int StopId { get; set; }
    public DateTime DepartureTime { get; set; }
    public DateTime ArrivalTime { get; set; }
}