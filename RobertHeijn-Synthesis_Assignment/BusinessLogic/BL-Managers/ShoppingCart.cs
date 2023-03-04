#region

using BusinessLogic.BL_Classes;
using BusinessLogic.BL_DaL_Interfaces;
using BusinessLogic.BL_Exceptions;

#endregion

namespace BusinessLogic.BL_Managers;

public sealed class ShoppingCart
{
    private readonly List<Item> _items = new();

    public ShoppingCart(Person? customer)
    {
        Customer = customer;
    }

    public ShoppingCart(int cartId, Person? customer = null)
    {
        CartId = cartId;
        Customer = customer;
    }

    public ShoppingCart()
    {
    }

    public int CartId { get; private set; }
    public IReadOnlyList<Item> CartItems => _items.AsReadOnly();
    public decimal TotalPrice => _items.Sum(i => i.Amount * i.Product!.Price);
    public Person? Customer { get; }

    public bool AdjustItemAmount(Item item, bool increase = true)
    {
	    switch (_items.Contains(item))
	    {
		    case true:
			    _items.First(i => i == item).AdjustAmount(item.Amount, increase);
			    return true;
		    case false when increase:
			    _items.Add(item);
			    return true;
		    default:
			    return false;
	    }
    }

    public bool RemoveItemFromCart(IShoppingCartActionable service, Item item)
    {
        if (!_items.Contains(item))
            throw new ItemNotInCartException("Item is not in cart.\nRefresh page.");
        if (!service.RemoveItemFromCart(this, item)) return false;
        _items.Remove(item);
        return true;
    }

    public void RemoveEmptyItemsFromCart(IShoppingCartActionable service)
    {
        if (service.RemoveEmptyItemsFromCart(this))
            _items.RemoveAll(i => i.Amount == 0);
    }

    public ShoppingCart GetCart(IShoppingCartActionable service)
    {
        return service.GetCart(this);
    }
    public int CreateCart(IShoppingCartActionable service)
    {
        CartId = service.CreateCart(this);
        return CartId;
    }

    public bool TransferAnonymousCartToUser(IShoppingCartActionable service, int cartId, string? userEmail)
    {
        return service.TransferAnonymousCartToUser(cartId, userEmail);
    }
}