namespace BusinessLogic.BL_Exceptions;

public class InvalidValueException : LogicLayerException
{
    public InvalidValueException(string message) : base(message)
    {
    }

    public InvalidValueException(string message, Exception innerException) : base(message, innerException)
    {
    }

    public InvalidValueException()
    {
    }
}