namespace PatternsBusStorage.Api.DTOs.BusStop;

public class BusStopUpdate
{
    public string StopName { get; set; }
    public decimal Latitude { get; set; }
    public decimal Longitude { get; set; }
    public string? LocationDescription { get; set; }
    public int CityId { get; set; }
}