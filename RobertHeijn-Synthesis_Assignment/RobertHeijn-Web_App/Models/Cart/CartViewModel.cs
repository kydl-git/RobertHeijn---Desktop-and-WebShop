#region

using BusinessLogic.BL_Managers;
using RobertHeijn_Web_App.Models.Account;

#endregion

namespace RobertHeijn_Web_App.Models.Cart;

public class CartViewModel
{
    public int CartId { get; set; }
    public List<CartItemViewModel> CartItems { get; set; } = new();
    public PersonViewModel Customer { get; set; }
    public decimal TotalPrice => Math.Round(CartItems.Sum(x=> x.Price * x.Quantity), 2);

    public CartViewModel(ShoppingCart cart)
    {
	    CartId = cart.CartId;
	    Customer = new PersonViewModel(cart.Customer!);
	    CartItems = cart.CartItems.Select(x => new CartItemViewModel(x)).ToList();
    }
    public CartViewModel()
	{
	}
}

