#region

using BusinessLogic.BL_Enums;

#endregion

namespace BusinessLogic.BL_Classes;

public sealed class Quantity
{
    public Quantity(int value, QuantityUnit unit)
    {
        Value = value;
        Unit = unit;
    }

    public int Value { get; }
    public QuantityUnit Unit { get; }
}