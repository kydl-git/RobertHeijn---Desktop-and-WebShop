using BusinessLogic.BL_Classes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Reflection;
using System.Security.Claims;
using BusinessLogic.BL_DaL_Interfaces;
using BusinessLogic.BL_Managers;
using BusinessLogic.Data_Exceptions;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using RobertHeijn_Web_App.Models.Cart;

namespace RobertHeijn_Web_App.Pages.Cart;

[Authorize]
public class CheckoutModel : PageModel
{
	private readonly IShoppingCartActionable _shoppingCartService;
	private readonly ILogger<CheckoutModel> _logger;
	private readonly IToastNotification _toastNotification;
	private readonly IPersonActionable _personService;
	private readonly ICredentialsActionable _credentialsService;
	private readonly IInventoryActionable _inventoryService;
	private readonly IProductActionable _productService;
	private string? cartId = null;

	public CheckoutModel(IShoppingCartActionable shoppingCartService, ILogger<CheckoutModel> logger, IToastNotification toastNotification, IPersonActionable personService, ICredentialsActionable credentialsService, IInventoryActionable inventoryService, IProductActionable productService)
	{
		_shoppingCartService = shoppingCartService;
		_logger = logger;
		_toastNotification = toastNotification;
		_personService = personService;
		_credentialsService = credentialsService;
		_inventoryService = inventoryService;
		_productService = productService;
	}

	public async Task OnGet()
	{
		await GetCartViewModel();
	}
	
	public async Task<IActionResult> OnPost(IEnumerable<CartItemViewModel> items)
	{
		IEnumerable<CartItemViewModel> cartItemViewModels = items as CartItemViewModel[] ?? items.ToArray();
		if(!cartItemViewModels.Any())
		{
			_toastNotification.AddErrorToastMessage("Your cart is empty");
			return RedirectToPage("/Inventory/ViewInventory");
		}
		try
		{
			await GetCartViewModel();
			if (!ModelState.IsValid)
			{
				return BadRequest();
			}
			Dictionary<int, int> itemsToUpdate = cartItemViewModels.ToDictionary(i => i.ProductId, i => i.Quantity);
			if (!_shoppingCartService.UpdateCartItemsAmount(new ShoppingCart(CartViewModel.CartId) , itemsToUpdate))
				_toastNotification.AddErrorToastMessage("Failed to update cart");
		}
		catch (ConnectionUnavailableException con)
		{
			_toastNotification.AddErrorToastMessage(con.Message);
			_logger.LogWarning("{PageName} => {Exception}, {Date}", "CheckOut", con.Message, DateTime.UtcNow.ToString("dd/MM/yyyy HH:mm:ss"));
			RedirectToPage("/Index");
		}
		catch (Exception e)
		{
			_toastNotification.AddErrorToastMessage("Something went wrong");
			_logger.LogWarning("{PageName} => {Exception}, {Date}", "CheckOut", e.Message, DateTime.UtcNow.ToString("dd/MM/yyyy HH:mm:ss"));
			RedirectToPage("/Index");
		}
		return RedirectToPage("/Order/OrderDeliveryType", new { id = CartViewModel.CartId });
	}

	public CartViewModel CartViewModel { get; set; }  = new();
	
	private async Task GetCartViewModel()
	{
		if(HttpContext.User.Identity is { IsAuthenticated: true })
		{
			CartViewModel = await GetOrCreateBasketForCustomer(Request.Cookies[Constants.CartCookieName]!);
		}
		else
		{
			GetOrSetBasketCookieAndCartId();
			CartViewModel = await GetOrCreateBasketForCustomer(cartId!);
		}
	}
	
	private async Task<CartViewModel> GetOrCreateBasketForCustomer(string shoppingcartId)
	{
		var model = new CartViewModel();
		try
		{
			Person person = new Person(new Credentials().ReadCredentialsByEmail(_credentialsService, HttpContext.User.FindFirstValue(ClaimTypes.Email))).GetPerson(_personService);
			var shoppingCart = new ShoppingCart(Convert.ToInt32(shoppingcartId), person);
			shoppingCart.CreateCart(_shoppingCartService);
			model = new CartViewModel(shoppingCart.GetCart(_shoppingCartService));
		
		}
		catch (ConnectionUnavailableException con)
		{
			_toastNotification.AddErrorToastMessage(con.Message);
			_logger.LogWarning("{PageName} => {Exception}, {Date}", "CheckOut", con.Message, DateTime.UtcNow.ToString("dd/MM/yyyy HH:mm:ss"));
			RedirectToPage("/Index");
		}
		catch(Exception e)
		{
			_toastNotification.AddErrorToastMessage("Something went wrong");
			_logger.LogWarning("{PageName} => {Exception}, {Date}", "CheckOut", e.Message, DateTime.UtcNow.ToString("dd/MM/yyyy HH:mm:ss"));
			RedirectToPage("/Index");
		}
		return model;
	}
	
	private void GetOrSetBasketCookieAndCartId()
	{
		if (Request.Cookies.ContainsKey(Constants.CartCookieName))
		{
			cartId = Request.Cookies[Constants.CartCookieName]!;
		}
		if(cartId != null)
			return;
		cartId = new ShoppingCart().CreateCart(_shoppingCartService).ToString();
		Response.Cookies.Append(Constants.CartCookieName, cartId, new CookieOptions
		{
			Expires = DateTime.Today.AddYears(10)
		});
	}

}