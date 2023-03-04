namespace BusinessLogic.BL_Exceptions;

public class InvalidOrSameOrderStatusException : LogicLayerException
{
    public InvalidOrSameOrderStatusException(string message) : base(message)
    {
    }

    public InvalidOrSameOrderStatusException(string message, Exception innerException) : base(message, innerException)
    {
    }

    public InvalidOrSameOrderStatusException()
    {
    }
}