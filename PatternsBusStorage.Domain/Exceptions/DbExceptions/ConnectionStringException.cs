namespace PatternsBusStorage.Domain.Exceptions.DbExceptions;

public class ConnectionStringException : Exception
{
    internal ConnectionStringException(string message) : base(message)
    {
        
    }
}