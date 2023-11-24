using System.Text.RegularExpressions;
using PatternsBusStorage.Domain.Mementos.Bus;

namespace PatternsBusStorage.Domain.Aggregates;

public class Bus
{
    public int BusId { get; set; }
    public string BusNumber { get; set; }
    public string? Model { get;  set; }
    public int ManufacturingYear { get; set; }
    public int Capacity { get; set; }
    public string Status { get; set; }

    public class BusBuilder
    {
        private readonly Bus _bus;

        public BusBuilder(string busNumber, string status)
        {
            _bus = new Bus
            {
                BusNumber = busNumber,
                Status = status
            };
        }

        public BusBuilder SetModel(string model)
        {
            _bus.Model = model;
            return this;
        }

        public BusBuilder SetManufacturingYear(int year)
        {
            _bus.ManufacturingYear = year;
            return this;
        }

        public BusBuilder SetCapacity(int capacity)
        {
            _bus.Capacity = capacity;
            return this;
        }

        public Bus Build()
        {
            if (!Regex.Match(_bus.BusNumber, "^[a-zA-Z]{2}[0-9]{4}[a-zA-Z]{2}$").Success)
            {
                throw new Exception("The bus number is in the wrong format");
            }else if (_bus.BusNumber.Length != 8)
            {
                throw new Exception("The length of the number can only be 8");
            }else if (_bus.ManufacturingYear is > 2023 or < 1900)
            {
                throw new Exception("Please set the valid year");
            }
            return _bus;
        }
        
    }
    
    public BusMemento SaveToMemento()
    {
        return new BusMemento(this);
    }

    public void RestoreFromMemento(BusMemento memento)
    {
        BusId = memento.BusId;
        BusNumber = memento.BusNumber;
        Model = memento.Model;
        ManufacturingYear = memento.ManufacturingYear;
        Capacity = memento.Capacity;
        Status = memento.Status;
    }
    
    public override string ToString()
    {
        return $"BusId: {BusId}, BusNumber: {BusNumber}, Model: {Model}," +
               $" ManufacturingYear: {ManufacturingYear}, Capacity: {Capacity}," +
               $" Status: {Status}";
    }
}