namespace RobertHeijn_Management_App.Models;
/// <summary>
/// Did not have any good ideas for a name, so I just called it like this.
/// </summary>
public class DgvProductModel
{
	public int ProductId { get; set; }
	public string ProductName { get; set; }
	public decimal Price { get; set; }
	public string Unit { get; set; }
	public string Category { get; set; }
	public string SubCategory { get; set; }
	public int Amount { get; set; }

	public DgvProductModel(InventoryProductModel product)
	{
		ProductId = product.Product!.Id;
		ProductName = product.Product!.Name!;
		Price = product.Product!.Price;
		Unit = product.Product!.Unit;
		Category = product.Product!.ParentCategoryName;
		SubCategory = product.Product!.SubCategoryName;
		Amount = product.AvailableAmount;
	}
}