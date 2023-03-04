namespace BusinessLogic.BL_Exceptions;

public class ProductNotAvailableException : LogicLayerException
{
    public ProductNotAvailableException(string message) : base(message)
    {
    }

    public ProductNotAvailableException(string message, Exception innerException) : base(message, innerException)
    {
    }

    public ProductNotAvailableException()
    {
    }
}