namespace PatternsBusStorage.Domain.Exceptions.DbExceptions;

public class RecordNotFoundException : Exception
{
    public RecordNotFoundException(string message) : base(message)
    {
        
    }
}