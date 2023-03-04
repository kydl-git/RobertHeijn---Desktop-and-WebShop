namespace BusinessLogic.Data_Exceptions;

public class SqlNoChangesMadeException : DataAccessException
{
    public SqlNoChangesMadeException(string message) : base(message)
    {
    }

    public SqlNoChangesMadeException(string message, Exception innerException) : base(message, innerException)
    {
    }

    public SqlNoChangesMadeException()
    {
    }
}