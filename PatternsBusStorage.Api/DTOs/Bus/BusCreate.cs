namespace PatternsBusStorage.Api.DTOs.Bus;

public class BusCreate
{
    public string BusNumber { get; set; }
    public string? Model { get; set; }
    public int ManufacturingYear { get; set; }
    public int Capacity { get; set; }
    public string Status { get; set; }
}