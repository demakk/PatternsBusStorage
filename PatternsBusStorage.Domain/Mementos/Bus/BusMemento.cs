namespace PatternsBusStorage.Domain.Mementos.Bus;

public class BusMemento
{
    public int BusId { get; set; }
    public string BusNumber { get; set; }
    public string? Model { get; set; }
    public int ManufacturingYear { get; set; }
    public int Capacity { get; set; }
    public string Status { get; set; }


    public BusMemento(Aggregates.Bus bus)
    {
        BusId = bus.BusId;
        BusNumber = bus.BusNumber;
        Model = bus.Model;
        ManufacturingYear = bus.ManufacturingYear;
        Capacity = bus.Capacity;
        Status = bus.Status;
    }
}