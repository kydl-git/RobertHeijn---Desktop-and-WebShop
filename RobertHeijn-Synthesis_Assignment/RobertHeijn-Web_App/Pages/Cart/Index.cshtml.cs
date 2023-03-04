using System.Security.Claims;
using BusinessLogic.BL_Classes;
using BusinessLogic.BL_DaL_Interfaces;
using BusinessLogic.BL_Managers;
using BusinessLogic.Data_Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NToastNotify;
using RobertHeijn_Web_App.Models.Cart;
using RobertHeijn_Web_App.Models.Inventory;
using static System.Int32;

namespace RobertHeijn_Web_App.Pages.Cart;

public class IndexModel : PageModel
{
	private readonly IShoppingCartActionable _shoppingCartService;
	private readonly ILogger<Pages.IndexModel> _logger;
	private readonly IToastNotification _toastNotification;
	private readonly IPersonActionable _personService;
	private readonly ICredentialsActionable _credentialsService;
	private readonly IInventoryActionable _inventoryService;
	private readonly IProductActionable _productService;

	public IndexModel(IToastNotification toastNotification, ICredentialsActionable credentialsService,IShoppingCartActionable shoppingCartService, ILoggerFactory factory, IPersonActionable personService, IInventoryActionable inventoryService, IProductActionable productService)
	{
		_shoppingCartService = shoppingCartService;
		_logger = factory.CreateLogger<Pages.IndexModel>();
		_toastNotification = toastNotification;
		_personService = personService;
		_inventoryService = inventoryService;
		_productService = productService;
		_credentialsService = credentialsService;
	}

	public CartViewModel CartViewModel { get; set; }  = new();
	public async Task OnGet()
	{
		CartViewModel = await GetOrCreateBasketForCustomer();
	}
		public async Task<IActionResult> OnPostAddToCart(InventoryProductViewModel item)
     	{
     		if (item?.ProductId == null)
     		{
     			return RedirectToPage("/Index");
     		}
     		try
     		{
     			Inventory inventory = new();
     			inventory.GetInventory(_inventoryService);
     			var product = inventory.Products.FirstOrDefault(x => x.Product!.Id == item.ProductId);
     			if (product == null)
     			{
     				return RedirectToPage("/Index");
     			}
     
     			var cartId = Convert.ToInt32(GetOrSetBasketCookieAndCartId());
     			var cart = new ShoppingCart(cartId);
     			if (!_shoppingCartService.AdjustItemAmount(cart, item.Map(_productService)))
     				_toastNotification.AddErrorToastMessage("Failed to add item to cart");
     			CartViewModel = new CartViewModel(cart.GetCart(_shoppingCartService));
     
     		}
     		catch (ConnectionUnavailableException con)
     		{
     			_toastNotification.AddErrorToastMessage(con.Message);
     			_logger.LogWarning("{PageName} => {Exception}, {Date}", "Shopping Cart", con.Message, DateTime.UtcNow.ToString("dd/MM/yyyy HH:mm:ss"));
     			RedirectToPage("/Index");
     			
     		}
     		catch(Exception e)
     		{
     			_toastNotification.AddErrorToastMessage("Something went wrong");
     			_logger.LogWarning("{PageName} => {Exception}, {Date}", "Shopping Cart", e.Message, DateTime.UtcNow.ToString("dd/MM/yyyy HH:mm:ss"));
     			RedirectToPage("/Index");
     		}
     		return RedirectToPage();
     	}
	public async Task OnPostUpdate(IEnumerable<CartItemViewModel> items)
	{
		if(!ModelState.IsValid)
		{
			_toastNotification.AddErrorToastMessage("Something went wrong");
			RedirectToPage("/Index");
		}
		
		CartViewModel = await GetOrCreateBasketForCustomer();
		try
		{
			var cartId = Convert.ToInt32(GetOrSetBasketCookieAndCartId());
			var cart = new ShoppingCart(cartId);
			Dictionary<int, int> itemsToUpdate = items.ToDictionary(i => i.ProductId, i => i.Quantity);
			if (!_shoppingCartService.UpdateCartItemsAmount(cart, itemsToUpdate))
				_toastNotification.AddErrorToastMessage("Failed to update cart");
			CartViewModel = new CartViewModel(cart.GetCart(_shoppingCartService));
		}
		catch (ConnectionUnavailableException con)
		{
			_toastNotification.AddErrorToastMessage(con.Message);
			_logger.LogWarning("{PageName} => {Exception}, {Date}", "Shopping Cart", con.Message, DateTime.UtcNow.ToString("dd/MM/yyyy HH:mm:ss"));
			RedirectToPage("/Index");
		}
		catch (Exception e)
		{
			_toastNotification.AddErrorToastMessage("Something went wrong");
			_logger.LogWarning("{PageName} => {Exception}, {Date}", "Shopping Cart", e.Message, DateTime.UtcNow.ToString("dd/MM/yyyy HH:mm:ss"));
			RedirectToPage("/Index");
		}
	}

	private async Task<CartViewModel> GetOrCreateBasketForCustomer()
	{
		var model = new CartViewModel();
		try
		{
			Person person = new Person(new Credentials().ReadCredentialsByEmail(_credentialsService, HttpContext.User.FindFirstValue(ClaimTypes.Email))).GetPerson(_personService);
			TryParse(GetOrSetBasketCookieAndCartId(), out int id);
			var shoppingCart = new ShoppingCart(id, person);
			shoppingCart.CreateCart(_shoppingCartService);
			model = new CartViewModel(shoppingCart.GetCart(_shoppingCartService));
		
		}
		catch (ConnectionUnavailableException con)
		{
			_toastNotification.AddErrorToastMessage(con.Message);
			_logger.LogWarning("{PageName} => {Exception}, {Date}", "Shopping Cart Page", con.Message, DateTime.UtcNow.ToString("dd/MM/yyyy HH:mm:ss"));
			RedirectToPage("/Index");
		}
		catch(Exception e)
		{
			_toastNotification.AddErrorToastMessage("Something went wrong");
			_logger.LogWarning("{PageName} => {Exception}, {Date}", "Shopping Cart Page", e.Message, DateTime.UtcNow.ToString("dd/MM/yyyy HH:mm:ss"));
			RedirectToPage("/Index");
		}
		return model;
	}
	private string GetOrSetBasketCookieAndCartId()
	{
		string? cartId = null;
		if (Request.Cookies.ContainsKey(Constants.CartCookieName))
		{
			cartId = Request.Cookies[Constants.CartCookieName]!;
		}
		if(cartId != null)
			return cartId;
		cartId = new ShoppingCart().CreateCart(_shoppingCartService).ToString();
		Response.Cookies.Append(Constants.CartCookieName, cartId, new CookieOptions
		{
			IsEssential = true,
			Expires = DateTime.Today.AddYears(10)
		});
		return cartId;
	}
}