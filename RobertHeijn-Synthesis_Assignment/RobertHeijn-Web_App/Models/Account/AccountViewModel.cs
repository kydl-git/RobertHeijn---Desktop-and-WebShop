using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RobertHeijn_Web_App.Models.Account;

public class AccountViewModel
{
	[DisplayName("Email address")]
	public string? Email { get; set; }
	[DisplayName("First name")]
	public string? FirstName { get; set; } 
	[DisplayName("Last name")]
	public string? LastName { get; set; } 
	[Phone]
	[DisplayName("Phone number")]
	public string? Phone { get; set; }
	[DisplayName("Role")]
	public string? Role { get; set; }
	public string StatusMessage { get; set; }
}