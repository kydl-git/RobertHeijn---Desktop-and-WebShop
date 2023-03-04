#region

using BusinessLogic.BL_Classes;
using BusinessLogic.BL_Managers;

#endregion

namespace BusinessLogic.BL_DaL_Interfaces;

public interface IShoppingCartActionable
{
	protected internal ShoppingCart GetCart(ShoppingCart cart);
	protected internal bool TransferAnonymousCartToUser(int cartId, string? userEmail);
	protected internal int CreateCart(ShoppingCart cart);
	public bool AdjustItemAmount(ShoppingCart cart, Item item, bool increase = true);
	public bool RemoveItemFromCart(ShoppingCart cart, Item item);
	public bool DeleteCart(ShoppingCart cart);
	public bool RemoveEmptyItemsFromCart(ShoppingCart cart);
	bool UpdateCartItemsAmount(ShoppingCart cart, Dictionary<int, int> items);
}