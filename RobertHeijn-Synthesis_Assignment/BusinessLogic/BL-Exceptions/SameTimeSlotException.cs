namespace BusinessLogic.BL_Exceptions;

public class SameTimeSlotException : LogicLayerException
{
    public SameTimeSlotException(string message) : base(message)
    {
    }

    public SameTimeSlotException(string message, Exception innerException) : base(message, innerException)
    {
    }

    public SameTimeSlotException()
    {
    }
}