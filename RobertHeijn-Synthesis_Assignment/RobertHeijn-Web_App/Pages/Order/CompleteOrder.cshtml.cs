#region

using System.Security.Claims;
using BusinessLogic.BL_Classes;
using BusinessLogic.BL_DaL_Interfaces;
using BusinessLogic.BL_Managers;
using BusinessLogic.Data_Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NToastNotify;

#endregion

namespace RobertHeijn_Web_App.Pages.Order;

[Authorize]
public class CompleteOrderModel : PageModel
{
	private readonly IAddressActionable _addressService;
	private readonly ICredentialsActionable _credentialsService;
	private readonly IHomeDeliveryActionable _homeDeliveryService;
	private readonly IInventoryActionable _inventoryService;
	private readonly ILogger<CompleteOrderModel> _logger;
	private readonly IOrderActionable _orderService;
	private readonly IPersonActionable _personService;
	private readonly IProductActionable _productService;

	private readonly IShoppingCartActionable _shoppingCartService;
	private readonly IToastNotification _toastNotification;

	public CompleteOrderModel(IShoppingCartActionable shoppingCartService, ILogger<CompleteOrderModel> logger, IToastNotification toastNotification, IPersonActionable personService, ICredentialsActionable credentialsService, IInventoryActionable inventoryService, IProductActionable productService, IHomeDeliveryActionable homeDeliveryService, IAddressActionable addressService, IOrderActionable orderService)
	{
		_shoppingCartService = shoppingCartService;
		_logger = logger;
		_toastNotification = toastNotification;
		_personService = personService;
		_credentialsService = credentialsService;
		_inventoryService = inventoryService;
		_productService = productService;
		_homeDeliveryService = homeDeliveryService;
		_addressService = addressService;
		_orderService = orderService;
	}

	public int CartId { get; set; }

	[BindProperty(SupportsGet = true)] public string? SelectedDeliveryType { get; set; }

	public List<Address> Addresses { get; set; } = new();
	public DeliveryOption DeliveryOption { get; set; }

	[BindProperty] public int SelectedAddressId { get; set; }

	public DateOnly DeliveryDate { get; set; }
	public List<TimeSlot> TimeSlots { get; set; } = new();
	public int TimeIndex { get; set; }
	public ShoppingCart Cart { get; set; } = new();


	public void OnGet(int cartId, string selectedDeliveryType, DateTime deliveryDay)
	{
		try
		{
			DeliveryDate = DateOnly.FromDateTime(deliveryDay);
			CartId = cartId;
			Person person = new Person(new Credentials().ReadCredentialsByEmail(_credentialsService, HttpContext.User.FindFirstValue(ClaimTypes.Email))).GetPerson(_personService);
			Cart = new ShoppingCart(cartId, person);
			SelectedDeliveryType = selectedDeliveryType;
			if (selectedDeliveryType == "PickUpDelivery")
			{
				DeliveryOption = new PickUpDelivery(DeliveryDate);
				TimeSlots = (DeliveryOption.GetType().GetProperty("HoursRange")!.GetValue(DeliveryOption)! as DeliveryHoursRange)!.TimeSlots.SelectMany(x => x.Value).Select(y => y.Value).ToList();
				Addresses = _addressService.GetPickUpAddresses();
			}
			else if (selectedDeliveryType == "HomeDelivery")
			{
				DeliveryOption = new HomeDelivery(person, DeliveryDate);
				(DeliveryOption as HomeDelivery)!.SetAvailableTimeSlots(_homeDeliveryService);
				TimeSlots = (DeliveryOption.GetType().GetProperty("HoursRange")!.GetValue(DeliveryOption)! as DeliveryHoursRange)!.TimeSlots.SelectMany(x => x.Value).Select(y => y.Value).ToList();
				Addresses = (person.Role!.GetType().GetProperty("GetAddresses")!.GetValue(person.Role)! as List<Address>)!;
			}
			else
			{
				RedirectToPage("/Cart/Index");
			}
		}
		catch (ConnectionUnavailableException con)
		{
			_toastNotification.AddErrorToastMessage(con.Message);
			_logger.LogWarning("{PageName} => {Exception}, {Date}", "Complete Order", con.Message, DateTime.UtcNow.ToString("dd/MM/yyyy HH:mm:ss"));
			RedirectToPage("/Index");
		}
		catch (Exception e)
		{
			_toastNotification.AddErrorToastMessage("Something went wrong");
			_logger.LogWarning("{PageName} => {Exception}, {Date}", "Complete Order", e.Message, DateTime.UtcNow.ToString("dd/MM/yyyy HH:mm:ss"));
			RedirectToPage("/Index");
		}
	}

	public Task<IActionResult> OnPost()
	{
		if (!ModelState.IsValid) return Task.FromResult<IActionResult>(Page());
		try
		{
			Person person = new Person(new Credentials().ReadCredentialsByEmail(_credentialsService, HttpContext.User.FindFirstValue(ClaimTypes.Email))).GetPerson(_personService);
			Cart = new ShoppingCart(Convert.ToInt32(Request.Cookies[Constants.CartCookieName]!), person);
			var address = Addresses.FirstOrDefault(x => x.Id == SelectedAddressId);
			DeliveryOption.SetAddress(address);
			var order = new BusinessLogic.BL_Classes.Order(person, DeliveryOption,TimeSlots[TimeIndex], address!);
			foreach (var item in Cart.CartItems)
			{
				order.AddItem(item);
			}

			if (order.CreateOrder(_orderService))
			{
				_shoppingCartService.DeleteCart(Cart);
				_toastNotification.AddSuccessToastMessage("Order has been placed");
				_logger.LogInformation("{PageName} => {Message}, {Date}", "Complete Order", "Order has been placed", DateTime.UtcNow.ToString("dd/MM/yyyy HH:mm:ss"));
				Response.Cookies.Delete(Constants.CartCookieName);
			}
		}
		catch (ConnectionUnavailableException con)
		{
			_toastNotification.AddErrorToastMessage(con.Message);
			_logger.LogWarning("{PageName} => {Exception}, {Date}", "Complete Order", con.Message, DateTime.UtcNow.ToString("dd/MM/yyyy HH:mm:ss"));
			RedirectToPage("/Index");
		}
		catch (Exception e)
		{
			_toastNotification.AddErrorToastMessage("Something went wrong");
			_logger.LogWarning("{PageName} => {Exception}, {Date}", "Complete Order", e.Message, DateTime.UtcNow.ToString("dd/MM/yyyy HH:mm:ss"));
			RedirectToPage("/Index");
		}
		return Task.FromResult<IActionResult>(RedirectToPage("Success"));
	}
}