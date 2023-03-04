namespace BusinessLogic.BL_Exceptions;

public class LogicLayerException : Exception
{
    protected LogicLayerException(string message) : base(message)
    {
    }

    protected LogicLayerException(string message, Exception innerException) : base(message, innerException)
    {
    }

    protected LogicLayerException()
    {
    }
}