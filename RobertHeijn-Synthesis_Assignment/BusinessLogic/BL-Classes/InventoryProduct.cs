#region

using BusinessLogic.BL_DaL_Interfaces;
using BusinessLogic.BL_Exceptions;

#endregion

namespace BusinessLogic.BL_Classes;

public sealed class InventoryProduct
{
	/// <summary>
	///     Initializes a new instance of the <see cref="InventoryProduct" /> class.
	/// </summary>
	/// <param name="product">The product <see cref="Product" />.</param>
	/// <param name="availableAmount">The available amount.</param>
	/// <param name="id">The id.</param>
	public InventoryProduct(Product? product, int availableAmount, int id = default)
	{
		Id = id;
		Product = product;
		AvailableAmount = availableAmount;
	}

	public InventoryProduct()
	{
	}

	public int Id { get; }
	public Product? Product { get; }
	public int AvailableAmount { get; private set; }

	public bool UpdateAvailableAmount(IInventoryActionable service, int amount)
	{
		if (amount < 0)
			throw new InvalidValueException("Amount cannot be negative");
		AvailableAmount = amount;
		return service.UpdateItemQuantityInInventory(this);
	}

	public InventoryProduct GetItemFromInventory(IInventoryActionable service)
	{
		return service.GetItemFromInventory(this);
	}

	public bool IsItemInStock(IInventoryActionable service)
	{
		return service.IsItemInStock(Product!);
	}
}