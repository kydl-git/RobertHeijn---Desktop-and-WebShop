namespace BusinessLogic.BL_Exceptions;

public class ObjectDuplicateException : LogicLayerException
{
    public ObjectDuplicateException(string message) : base(message)
    {
    }

    public ObjectDuplicateException(string message, Exception innerException) : base(message, innerException)
    {
    }

    public ObjectDuplicateException()
    {
    }
}