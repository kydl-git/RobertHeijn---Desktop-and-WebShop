namespace BusinessLogic.Data_Exceptions;

public class DataAccessException : Exception
{
    protected DataAccessException(string message) : base(message)
    {
    }

    protected DataAccessException(string message, Exception innerException) : base(message, innerException)
    {
    }

    protected DataAccessException()
    {
    }
}