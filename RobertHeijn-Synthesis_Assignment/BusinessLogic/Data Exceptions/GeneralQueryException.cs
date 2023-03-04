namespace BusinessLogic.Data_Exceptions;

public class GeneralQueryException : DataAccessException
{
    public GeneralQueryException(string message) : base(message)
    {
    }

    public GeneralQueryException(string message, Exception innerException) : base(message, innerException)
    {
    }

    public GeneralQueryException()
    {
    }
}