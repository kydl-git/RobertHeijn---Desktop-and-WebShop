namespace BusinessLogic.BL_Exceptions;

public class UnavailableStockException : LogicLayerException
{
    public UnavailableStockException(string message) : base(message)
    {
    }

    public UnavailableStockException(string message, Exception innerException) : base(message, innerException)
    {
    }

    public UnavailableStockException()
    {
    }
}