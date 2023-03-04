using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RobertHeijn_Web_App.Models.Account;

public class EditDetailsModel
{
	[EmailAddress]
	[DisplayName("Email address")]
	public string? Email { get; set; }
	[Phone]
	[DisplayName("Phone number")]
	public string PhoneNumber { get; set; }
	public string? StatusMessage { get; set; }
}