#region

using BusinessLogic.BL_Exceptions;
using Humanizer;

#endregion

namespace BusinessLogic.BL_Classes;

public sealed class Item : IEquatable<Item>
{
    /// <summary>Initializes a new instance of the <see cref="Item" /> class.</summary>
    public Item(Product? product, int amount = 1)
    {
	    if (amount < 1)
			throw new InvalidValueException("Amount must be greater than 1");
        Product = product;
        Amount = amount;
    }

    public Item(InventoryProduct product, int amount = 1)
    {
	    if (amount <= 1)
		    throw new InvalidValueException("Amount must be greater than 1");
        Product = product.Product;
        Amount = amount;
    }

    public Item()
    {
    }

    public Product? Product { get; }
    public int Amount { get; private set; }

    /// <summary>
    ///     Determines whether the specified
    ///     <see cref="T:BusinessLogic.BL_Classes.Item" /> is equal to the current
    ///     <see cref="T:BusinessLogic.BL_Classes.Item" />.
    /// </summary>
    /// <param name="other">
    ///     The <see cref="T:BusinessLogic.BL_Classes.Item" /> to compare
    ///     with the current <see cref="T:BusinessLogic.BL_Classes.Item" />.
    /// </param>
    /// <returns>
    ///     <see langword="true" /> if the specified
    ///     <see cref="T:BusinessLogic.BL_Classes.Item" /> is equal to the current
    ///     <see cref="T:BusinessLogic.BL_Classes.Item" />; otherwise,
    ///     <see langword="false" />.
    /// </returns>
    public bool Equals(Item? other)
    {
        if (ReferenceEquals(null, other)) return false;
        return Product == other.Product;
    }

    public bool AdjustAmount(int value, bool increaseAmount = false)
    {
        switch (value)
        {
            case < 0:
                throw new InvalidValueException("Quantity cannot be negative");
            case 0:
	            SetAmount(value);
                break;
            case > 0:
                CalculateQuantity(value, increaseAmount);
                break;
        }

        return true;
    }

    public void SetAmount(int value)
    {
	    if (value <= 0)
		    throw new InvalidValueException("Amount must be greater than 0");
	    Amount = value;
    }
    private void CalculateQuantity(int value, bool increaseAmount = false)
    {
        switch (increaseAmount)
        {
            case false when Amount == 0 || Amount < value:
                throw new InvalidValueException($"Not enough quantity for product {Product!.Name.Humanize(LetterCasing.LowerCase)} in shopping cart");
            case true:
                Amount += value;
                break;
            default:
                Amount -= value;
                break;
        }
    }

    /// <summary>
    ///     Returns a value that indicates whether the
    ///     <see cref="T:BusinessLogic.BL_Classes.Product" />s of two
    ///     <see cref="T:BusinessLogic.BL_Classes.Item" /> objects are equal.
    /// </summary>
    /// <param name="left">
    ///     The first <see cref="T:BusinessLogic.BL_Classes.Product" />
    ///     to compare.
    /// </param>
    /// <param name="right">
    ///     The second
    ///     <see cref="T:BusinessLogic.BL_Classes.Product" /> to compare.
    /// </param>
    /// <returns>
    ///     true if the <paramref name="left" /> and <paramref name="right" />
    ///     parameters have the same value; otherwise, false.
    /// </returns>
    public static bool operator ==(Item? left, Item? right)
    {
        return left!.Equals(right);
    }

    /// <summary>
    ///     Returns a value that indicates whether the
    ///     <see cref="T:BusinessLogic.BL_Classes.Product" />s of two
    ///     <see cref="T:BusinessLogic.BL_Classes.Item" /> objects have different
    ///     values.
    /// </summary>
    /// <param name="left">
    ///     The first <see cref="T:BusinessLogic.BL_Classes.Product" />
    ///     to compare.
    /// </param>
    /// <param name="right">
    ///     The second
    ///     <see cref="T:BusinessLogic.BL_Classes.Product" /> to compare.
    /// </param>
    /// <returns>
    ///     true if <paramref name="left" /> and <paramref name="right" /> are not
    ///     equal; otherwise, false.
    /// </returns>
    public static bool operator !=(Item? left, Item? right)
    {
        return !left!.Equals(right);
    }
}