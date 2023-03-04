namespace BusinessLogic.BL_Exceptions;

public class InvalidOrSameDeliveryDayException : LogicLayerException
{
    public InvalidOrSameDeliveryDayException(string message) : base(message)
    {
    }

    public InvalidOrSameDeliveryDayException(string message, Exception innerException) : base(message, innerException)
    {
    }

    public InvalidOrSameDeliveryDayException()
    {
    }
}