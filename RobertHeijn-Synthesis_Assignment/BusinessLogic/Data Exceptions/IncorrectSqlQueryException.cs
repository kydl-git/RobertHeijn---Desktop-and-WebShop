namespace BusinessLogic.Data_Exceptions;

public class IncorrectSqlQueryException : DataAccessException
{
    public IncorrectSqlQueryException(string message) : base(message)
    {
    }

    public IncorrectSqlQueryException(string message, Exception innerException) : base(message, innerException)
    {
    }

    public IncorrectSqlQueryException()
    {
    }
}