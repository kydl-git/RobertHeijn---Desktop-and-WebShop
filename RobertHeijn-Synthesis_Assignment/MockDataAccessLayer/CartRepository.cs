using BusinessLogic.BL_Classes;
using BusinessLogic.BL_DaL_Interfaces;
using BusinessLogic.BL_Managers;

namespace MockDataAccessLayer;

public class CartRepository : IShoppingCartActionable
{
	private const int CARTS = 10;

	static CartRepository()
	{
		 CreateCarts();
	}
	public static List<ShoppingCart> Carts {get; set; }
	
	private static void CreateCarts()
	{
		for (int i = 0; i < CARTS; i++)
		{
			var cart = new ShoppingCart(i, new Person(new Credentials($"email{i}", $"password{i}"), $"firstName{i}", $"lastName{i}", $"phone{i}", i, new Customer(i)));
			Carts.Add(cart);
		}
	}
	public ShoppingCart GetCart(ShoppingCart cart)
	{
		return Carts.FirstOrDefault(c => c.CartId == cart.CartId)!;
	}

	public bool TransferAnonymousCartToUser(int cartId, string userEmail)
	{
		var cart = Carts.FirstOrDefault(c => c.CartId == cartId);
		if (cart is null)
		{
			return false;
		}
		Carts.Remove(cart);
		Carts.Add(new ShoppingCart(cart.CartId, new Person(new Credentials(userEmail, $"userEmail"), $"FN{cart.CartId}", $"LN{cart.CartId}", $"Phone{cart.CartId}", cart.CartId, new Customer(cart.CartId))));
		return true;
	}

	public int CreateCart(ShoppingCart cart)
	{
		Carts.Add(cart);
		return cart.CartId;
	}

	public bool AdjustItemAmount(ShoppingCart cart, Item item, bool increase = true)
	{
		throw new NotImplementedException();
	}

	public bool RemoveItemFromCart(ShoppingCart cart, Item item)
	{
		throw new NotImplementedException();
	}

	public bool DeleteCart(ShoppingCart cart)
	{
		throw new NotImplementedException();
	}

	public bool RemoveEmptyItemsFromCart(ShoppingCart cart)
	{
		throw new NotImplementedException();
	}

	public bool UpdateCartItemsAmount(ShoppingCart cart, Dictionary<int, int> items)
	{
		throw new NotImplementedException();
	}
}