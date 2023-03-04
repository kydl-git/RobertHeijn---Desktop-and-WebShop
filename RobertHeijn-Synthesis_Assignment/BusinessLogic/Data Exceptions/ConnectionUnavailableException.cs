namespace BusinessLogic.Data_Exceptions;

public class ConnectionUnavailableException : DataAccessException
{
    public ConnectionUnavailableException(string message) : base(message)
    {
    }

    public ConnectionUnavailableException(string message, Exception innerException) : base(message, innerException)
    {
    }

    public ConnectionUnavailableException()
    {
    }
}