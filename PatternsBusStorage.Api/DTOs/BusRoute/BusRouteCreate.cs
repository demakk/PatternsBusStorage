namespace PatternsBusStorage.Api.DTOs.BusRoute;

public class BusRouteCreate
{
    public string RouteName { get; set; }
    public string? RouteDescription { get; set; }
    public string StartLocation { get; set; }
    public string EndLocation { get; set; }
    public decimal? Distance { get; set; }
}