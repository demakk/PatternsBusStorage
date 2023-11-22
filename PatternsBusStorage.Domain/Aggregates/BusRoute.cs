namespace PatternsBusStorage.Domain.Aggregates;

public class BusRoute
{
    public int RouteId { get; set; }
    public string RouteName { get; set; }
    public string? RouteDescription { get; set; }
    public string StartLocation { get; set; }
    public string EndLocation { get; set; }
    public decimal? Distance { get; set; }
    
    
}