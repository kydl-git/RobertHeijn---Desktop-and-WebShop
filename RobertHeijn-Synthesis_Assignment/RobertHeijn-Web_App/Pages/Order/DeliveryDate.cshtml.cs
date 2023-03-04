using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using BusinessLogic.BL_Classes;
using BusinessLogic.BL_Managers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RobertHeijn_Web_App.Pages.Order;

[Authorize]
public class DeliveryDateModel : PageModel
{
	[Required]
	[DataType(DataType.Date)]
	[BindProperty(SupportsGet = true), DisplayName("Delivery Date")]
	public DateTime DeliveryDate { get; set; }
	[BindProperty(SupportsGet = true)]
	public string? SelectedDeliveryType { get; set; }
	[BindProperty(SupportsGet = true)]
	public int? CartId { get; set; }
	
	public void OnGet(int cartId, string selectedDeliveryType)
	{    
		CartId = cartId;
		SelectedDeliveryType = selectedDeliveryType;
	}
	public IActionResult OnPost()
	{
		if(!ModelState.IsValid) return Page();
		return RedirectToPage("./CompleteOrder", new { id = CartId, deliveryType = SelectedDeliveryType, deliveryDate = DeliveryDate });
	}
}