namespace PatternsBusStorage.Bll.DTOs;

public class ClosestBus
{
    public string BusNumber { get; set; }
    public string RouteName { get; set; }
    public string RouteDescription { get; set; }
    public string StartDestination { get; set; }
    public string FinalDestination { get; set; }
    public DateTime ArrivalTime { get; set; }
    public DateTime DepartureTime { get; set; }
}