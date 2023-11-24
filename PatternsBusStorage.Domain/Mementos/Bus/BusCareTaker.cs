namespace PatternsBusStorage.Domain.Mementos.Bus;

public class BusCareTaker
{
    private readonly List<BusMemento> _mementos = new();

    public void AddMemento(BusMemento memento)
    {
        _mementos.Add(memento);
    }

    public BusMemento GetMemento(int index)
    {
        if (index >= 0 && index < _mementos.Count)
        {
            return _mementos[index];
        }

        throw new IndexOutOfRangeException("Invalid Memento index");
    }
}