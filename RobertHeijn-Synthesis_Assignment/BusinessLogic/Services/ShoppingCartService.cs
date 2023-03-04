#region

using BusinessLogic.BL_Classes;
using BusinessLogic.BL_DaL_Interfaces;
using BusinessLogic.BL_Managers;

#endregion

namespace BusinessLogic.Services;

public sealed class ShoppingCartService : IShoppingCartActionable
{
    private readonly IShoppingCartActionable _shoppingCartRepository;

    /// <summary>
    ///     Initializes a new instance of the <see cref="ShoppingCartService" /> class.
    /// </summary>
    /// <param name="shoppingCartRepository"></param>
    public ShoppingCartService(IShoppingCartActionable shoppingCartRepository)
    {
        _shoppingCartRepository = shoppingCartRepository;
    }

    public ShoppingCart GetCart(ShoppingCart cart)
    {
        return _shoppingCartRepository.GetCart(cart);
    }

    public bool TransferAnonymousCartToUser(int cartId, string? userEmail)
    {
        return _shoppingCartRepository.TransferAnonymousCartToUser(cartId, userEmail);
    }

    public int CreateCart(ShoppingCart cart)
    {
        return _shoppingCartRepository.CreateCart(cart);
    }

    public bool AdjustItemAmount(ShoppingCart cart, Item item, bool increase = true)
    {
	    return cart.AdjustItemAmount(item, increase) && _shoppingCartRepository.AdjustItemAmount(cart, cart.CartItems.First(i => i == item));
    }

    public bool RemoveItemFromCart(ShoppingCart cart, Item item)
    {
        return _shoppingCartRepository.RemoveItemFromCart(cart, item);
    }

    public bool DeleteCart(ShoppingCart cart)
    {
        return _shoppingCartRepository.DeleteCart(cart);
    }

    public bool RemoveEmptyItemsFromCart(ShoppingCart cart)
    {
        return _shoppingCartRepository.RemoveEmptyItemsFromCart(cart);
    }

    public bool UpdateCartItemsAmount(ShoppingCart cart, Dictionary<int, int> items)
    {
	    return _shoppingCartRepository.UpdateCartItemsAmount(cart, items);
    }

}