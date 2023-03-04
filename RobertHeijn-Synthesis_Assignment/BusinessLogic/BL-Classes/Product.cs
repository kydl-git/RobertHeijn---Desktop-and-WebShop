#region

using BusinessLogic.BL_DaL_Interfaces;
using BusinessLogic.BL_Exceptions;

#endregion

namespace BusinessLogic.BL_Classes;

public sealed class Product : IEquatable<Product>
{
	public Product(int id, string? name, decimal price, Category? subCategory, Quantity? quantity)
	{
		Id = id;
		Name = name;
		Price = price;
		SubCategory = subCategory;
		Quantity = quantity;
	}

	public Product(string? name, decimal price, Category? subCategory, Quantity? quantity)
	{
		Name = name;
		Price = price;
		SubCategory = subCategory;
		Quantity = quantity;
	}

	public Product()
	{
	}

	public int Id { get; private set; }
	public string? Name { get; }
	public decimal Price { get; private set; }
	public Category? SubCategory { get; }
	public Quantity? Quantity { get; set; }

	/// <summary>
	///     Determines whether the specified
	///     <see cref="T:BusinessLogic.BL_Classes.Product" /> is equal to
	///     the current <see cref="T:BusinessLogic.BL_Classes.Product" />.
	/// </summary>
	/// <param name="other">
	///     The <see cref="T:BusinessLogic.BL_Classes.Product" /> to compare with the
	///     current <see cref="T:BusinessLogic.BL_Classes.Product" />.
	/// </param>
	/// <returns>
	///     <see langword="true" /> if the specified
	///     <see cref="T:BusinessLogic.BL_Classes.Product" /> is
	///     equal to the current <see cref="T:BusinessLogic.BL_Classes.Product" />;
	///     otherwise, <see langword="false" />.
	/// </returns>
	public bool Equals(Product? other)
	{
		if (ReferenceEquals(null, other)) return false;
		if (ReferenceEquals(this, other)) return true;
		return string.Equals(Name, other.Name) && Price == other.Price && Equals(SubCategory!.Name, other.SubCategory!.Name) && Equals(Quantity!.Value, other.Quantity!.Value) && Equals(Quantity.Unit , other.Quantity.Unit);
	}

	public bool CreateProduct(IProductActionable productService)
	{
		Id = productService.CreateProduct(this);
		return Id > 0;
	}

	public bool UpdateProductPrice(IProductActionable productService, decimal price)
	{
		if (price <= 0)
			throw new InvalidValueException("Price must be greater than 0");
		Price = productService.UpdateProductPrice(this, price) ? price : Price;
		return Price == price;
	}

	public bool UpdateProductQuantity(IProductActionable productService, int quantityValue)
	{
		if (quantityValue <= 0)
			throw new InvalidValueException("Quantity must be greater than 0");
		Quantity = productService.UpdateProductQuantity(this, quantityValue) ? new Quantity(quantityValue, Quantity!.Unit) : Quantity;
		return Quantity?.Value == quantityValue;
	}

	/// <summary>
	///     Returns a value that indicates whether two
	///     <see cref="T:BusinessLogic.BL_Classes.Product" /> objects are equal.
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
	///     <see langword="true" /> if the <paramref name="left" /> and
	///     <paramref name="right" />
	///     parameters have the same value; otherwise, <see langword="false" />.
	/// </returns>
	public static bool operator ==(Product? left, Product? right)
	{
		return left!.Equals(right);
	}

	/// <summary>
	///     Returns a value that indicates whether two
	///     <see cref="T:BusinessLogic.BL_Classes.Product" /> objects have different
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
	///     <see langword="true" /> if <paramref name="left" /> and
	///     <paramref name="right" /> are not
	///     equal; otherwise, <see langword="false" />.
	/// </returns>
	public static bool operator !=(Product? left, Product? right)
	{
		return !left!.Equals(right);
	}
}