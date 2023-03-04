using BusinessLogic.BL_Classes;
using BusinessLogic.BL_DaL_Interfaces;
using BusinessLogic.Data_Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NToastNotify;
using RobertHeijn_Web_App.Pages.Cart;

namespace RobertHeijn_Web_App.Pages.Order;

public class OrderDeliveryTypeModel : PageModel
{
	private readonly IShoppingCartActionable _shoppingCartService;
	private readonly ILogger<OrderDeliveryTypeModel> _logger;
	private readonly IToastNotification _toastNotification;
	private readonly IPersonActionable _personService;
	private readonly ICredentialsActionable _credentialsService;
	private readonly IInventoryActionable _inventoryService;
	private readonly IProductActionable _productService;

	public OrderDeliveryTypeModel(IToastNotification toastNotification, ILogger<OrderDeliveryTypeModel> logger, IShoppingCartActionable shoppingCartService, IPersonActionable personService, ICredentialsActionable credentialsService, IInventoryActionable inventoryService, IProductActionable productService)
	{
		_toastNotification = toastNotification;
		_logger = logger;
		_shoppingCartService = shoppingCartService;
		_personService = personService;
		_credentialsService = credentialsService;
		_inventoryService = inventoryService;
		_productService = productService;
	}

	public int CartId { get; set; }
	public Dictionary<string, DeliveryOption> DeliveryTypes { get; set; }
	[BindProperty(SupportsGet = true)]
	public string SelectedDeliveryType { get; set; }
	public void OnGet(int cartId)
	{
		CartId = cartId;
		try
		{
			DeliveryTypes = AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes()).Where(x=> typeof(DeliveryOption).IsAssignableFrom(x) && x is { IsInterface: false, IsAbstract: false }).ToDictionary(x=>x.Name!, x => (DeliveryOption)Activator.CreateInstance(x)!)!;
		}
		catch (ConnectionUnavailableException con)
		{
			_toastNotification.AddErrorToastMessage(con.Message);
			_logger.LogWarning("{PageName} => {Exception}, {Date}", "OrderDeliveryType", con.Message, DateTime.UtcNow.ToString("dd/MM/yyyy HH:mm:ss"));
			RedirectToPage("/Index");
		}
		catch (Exception e)
		{
			_toastNotification.AddErrorToastMessage("Something went wrong");
			_logger.LogWarning("{PageName} => {Exception}, {Date}", "OrderDeliveryType", e.Message, DateTime.UtcNow.ToString("dd/MM/yyyy HH:mm:ss"));
			RedirectToPage("/Index");
		}
	}

	public IActionResult OnPostChoose()
	{
		if(!ModelState.IsValid) return Page();
		return RedirectToPage("./DeliveryDate", new {cartId = CartId, deliveryOption = SelectedDeliveryType});
	}
}