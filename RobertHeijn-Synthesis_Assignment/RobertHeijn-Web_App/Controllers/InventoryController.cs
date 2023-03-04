using BusinessLogic.BL_Classes;
using BusinessLogic.BL_DaL_Interfaces;
using BusinessLogic.BL_Managers;
using BusinessLogic.BL_Validation;
using BusinessLogic.Data_Exceptions;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using RobertHeijn_Web_App.Models.Inventory;

namespace RobertHeijn_Web_App.Controllers;

[Route("[controller]/[action]")]
public class InventoryController : Controller
{
	private readonly IToastNotification _toastNotification;
	private readonly ICredentialsActionable _credentialsService;
	private readonly ILogger<InventoryController> _logger;
	private readonly IPersonActionable _personService;
	private readonly IValidatable _validation;
	private readonly IInventoryActionable _inventoryService;
	private readonly IShoppingCartActionable _shoppingCartService;
	private readonly IProductActionable _productService;
	
	[TempData] public string StatusMessage { get; set; }
	
	public InventoryController(IToastNotification toastNotification, ICredentialsActionable credentialsService, ILogger<InventoryController> logger, IPersonActionable personService, IValidatable validation, IInventoryActionable inventoryService, IShoppingCartActionable shoppingCartService, IProductActionable productService)
	{
		_toastNotification = toastNotification;
		_credentialsService = credentialsService;
		_logger = logger;
		_personService = personService;
		_validation = validation;
		_inventoryService = inventoryService;
		_shoppingCartService = shoppingCartService;
		_productService = productService;
	}

	[HttpGet]
	public Task<IActionResult> ViewInventory()
	{
		InventoryViewModel model = new();
		try
		{
			Inventory inventory = new();
			inventory.GetInventory(_inventoryService);
			model.Map(inventory);
		}
		catch (ConnectionUnavailableException con)
		{
			_toastNotification.AddErrorToastMessage(con.Message);
			_logger.LogWarning("{PageName} => {Exception}, {Date}", "MyAccount", con.Message, DateTime.UtcNow.ToString("dd/MM/yyyy HH:mm:ss"));
			return Task.FromResult<IActionResult>(RedirectToPage("/Index"));
			
		}
		catch(Exception e)
		{
			_toastNotification.AddErrorToastMessage("Something went wrong");
			_logger.LogWarning("{PageName} => {Exception}, {Date}", "MyAccount", e.Message, DateTime.UtcNow.ToString("dd/MM/yyyy HH:mm:ss"));
			Task.FromResult<IActionResult>(RedirectToPage("/Index"));
		}
		return Task.FromResult<IActionResult>(View(model));
	}
	// [HttpPost]
	// [ValidateAntiForgeryToken]
	// public Task<IActionResult> OnPostAddToCart(int ProductId)
	// {
	// 	if (ProductId < 1)
	// 	{
	// 		return Task.FromResult<IActionResult>(RedirectToPage("/Index"));
	// 	}
	// 	try
	// 	{
	// 		Inventory inventory = new();
	// 		inventory.GetInventory(_inventoryService);
	// 		var product = inventory.Products.FirstOrDefault(x => x.Product!.Id == ProductId);
	// 		if (product == null)
	// 		{
	// 			return Task.FromResult<IActionResult>(RedirectToPage("/Index"));
	// 		}
	//
	// 		var cartId = Convert.ToInt32(GetOrSetBasketCookieAndCartId());
	// 		var cart = new ShoppingCart(cartId);
	// 		if (!_shoppingCartService.AdjustItemAmount(cart, new Item(product)))
	// 			_toastNotification.AddErrorToastMessage("Failed to add item to cart");
	// 		else
	// 			_toastNotification.AddSuccessToastMessage("Item added to cart");
	//
	// 	}
	// 	catch (ConnectionUnavailableException con)
	// 	{
	// 		_toastNotification.AddErrorToastMessage(con.Message);
	// 		_logger.LogWarning("{PageName} => {Exception}, {Date}", "Shopping Cart", con.Message, DateTime.UtcNow.ToString("dd/MM/yyyy HH:mm:ss"));
	// 		RedirectToPage("/Index");
	// 		
	// 	}
	// 	catch(Exception e)
	// 	{
	// 		_toastNotification.AddErrorToastMessage("Something went wrong");
	// 		_logger.LogWarning("{PageName} => {Exception}, {Date}", "Shopping Cart", e.Message, DateTime.UtcNow.ToString("dd/MM/yyyy HH:mm:ss"));
	// 		RedirectToPage("/Index");
	// 	}
	// 	return Task.FromResult<IActionResult>(RedirectToPage("/Cart/Index"));
	// }
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