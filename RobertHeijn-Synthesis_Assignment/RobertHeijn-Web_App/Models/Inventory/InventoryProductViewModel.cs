using System.ComponentModel;
using BusinessLogic.BL_Classes;
using BusinessLogic.BL_DaL_Interfaces;
using Humanizer;

namespace RobertHeijn_Web_App.Models.Inventory;

public class InventoryProductViewModel
{
	[Browsable(false)]
	public int Id { get; set; }
	public int ProductId { get; set; }
	public string ProductName { get; set; }
	public decimal Price { get; set; }
	[DisplayName("Unit")]
	public string Unit { get; set; }
	public string Category { get; set; }
	public string SubCategory { get; set; }
	public int Amount { get; set; }
	
	
	public InventoryProductViewModel Map(InventoryItemViewModel inventoryProduct)
	{
		Id = inventoryProduct.Id;
		ProductId = inventoryProduct.Product.Id;
		ProductName = inventoryProduct.Product.Name;
		Price = inventoryProduct.Product.Price;
		Unit = inventoryProduct.Product.Quantity! == 1 ? $"{inventoryProduct.Product.Quantity!} {inventoryProduct.Product.QuantityUnit.Humanize(LetterCasing.LowerCase)}" : $"{inventoryProduct.Product.Quantity!} {inventoryProduct.Product.QuantityUnit.Humanize(LetterCasing.LowerCase)}s";
		Category = inventoryProduct.Product.SubCategory.ParentCategoryName;
		SubCategory = inventoryProduct.Product.SubCategory.Name;
		Amount = inventoryProduct.AvailableAmount;
		return this;
	}

	public Item Map(IProductActionable service)
	{
		return new Item(service.GetAllProducts().First(p => p.Id == ProductId), Amount);
	}
}