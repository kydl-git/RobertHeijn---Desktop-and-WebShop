namespace BusinessLogic.BL_Exceptions;

public class ItemNotInCartException : LogicLayerException
{
    public ItemNotInCartException(string message) : base(message)
    {
    }

    public ItemNotInCartException(string message, Exception innerException) : base(message, innerException)
    {
    }

    public ItemNotInCartException()
    {
    }
}