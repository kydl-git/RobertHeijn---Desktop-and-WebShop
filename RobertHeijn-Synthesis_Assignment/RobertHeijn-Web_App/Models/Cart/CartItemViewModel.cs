using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using BusinessLogic.BL_Classes;

namespace RobertHeijn_Web_App.Models.Cart;

public class CartItemViewModel
{
	public int ProductId { get; set; }
	public string ProductName { get; set; }
	public decimal Price { get; set; }
	[Range(0,int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
	public int Quantity { get; set; }
	
	public CartItemViewModel(Item item)
	{
		ProductId = item.Product!.Id;
		ProductName = item.Product!.Name!;
		Price = item.Product.Price;
		Quantity = item.Amount;
	}
	
}