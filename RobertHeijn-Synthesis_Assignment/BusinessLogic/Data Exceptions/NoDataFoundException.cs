namespace BusinessLogic.Data_Exceptions;

public class NoDataFoundException : DataAccessException
{
    public NoDataFoundException(string message) : base(message)
    {
    }

    public NoDataFoundException(string message, Exception innerException) : base(message, innerException)
    {
    }

    public NoDataFoundException()
    {
    }
}