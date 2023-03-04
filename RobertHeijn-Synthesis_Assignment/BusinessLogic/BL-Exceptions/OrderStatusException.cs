namespace BusinessLogic.BL_Exceptions;

public class OrderStatusException : LogicLayerException
{
    public OrderStatusException(string message) : base(message)
    {
    }

    public OrderStatusException(string message, Exception innerException) : base(message, innerException)
    {
    }

    public OrderStatusException()
    {
    }
}