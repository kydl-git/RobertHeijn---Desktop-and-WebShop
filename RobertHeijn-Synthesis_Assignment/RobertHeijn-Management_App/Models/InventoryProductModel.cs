using BusinessLogic.BL_Classes;
using System.ComponentModel;

namespace RobertHeijn_Management_App.Models
{
	public class InventoryProductModel
	{
		[Browsable(false)]
		public int Id { get; }
		public ProductModel? Product { get; }
		[DisplayName("Available Amount")]
		public int AvailableAmount { get; set; }

		public InventoryProductModel(InventoryProduct inventoryProduct)
		{
			Id = inventoryProduct.Id;
			Product = new(inventoryProduct.Product!);
			AvailableAmount = inventoryProduct.AvailableAmount;
		}

		public InventoryProductModel()
		{

		}
	}
}
