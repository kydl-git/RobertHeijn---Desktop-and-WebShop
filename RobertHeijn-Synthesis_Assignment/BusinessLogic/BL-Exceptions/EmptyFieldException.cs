namespace BusinessLogic.BL_Exceptions;

public class EmptyFieldException : LogicLayerException
{
    public EmptyFieldException(string message) : base(message)
    {
    }

    public EmptyFieldException(string message, Exception innerException) : base(message, innerException)
    {
    }

    public EmptyFieldException()
    {
    }
}
