#region

using BusinessLogic.BL_Classes;
using BusinessLogic.BL_DaL_Interfaces;
using BusinessLogic.BL_Validation;
using BusinessLogic.Data_Exceptions;
using BusinessLogic.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NToastNotify;
using RobertHeijn_Web_App.ExtensionClasses;
using RobertHeijn_Web_App.Models.Account;

#endregion

namespace RobertHeijn_Web_App.Areas.Identity.Pages.Account;
[AllowAnonymous]
public class RegisterPersonalInfoModel : PageModel
{
	private readonly CredentialsService _credentialsService;
	private readonly ILogger<RegisterPersonalInfoModel> _logger;
	private readonly PersonService _personService;
	private readonly IToastNotification _toastNotification;
	private readonly IValidatable _validatable;

	public RegisterPersonalInfoModel(ILogger<RegisterPersonalInfoModel> logger, IPersonActionable personService, ICredentialsActionable credentialsService, IToastNotification toastNotification, IValidatable validatable)
	{
		_personService = (PersonService)personService;
		_credentialsService = (CredentialsService)credentialsService;
		_logger = logger;
		_toastNotification = toastNotification;
		_validatable = validatable;
	}

	[BindProperty] public PersonViewModel Person { get; set; }

	public Credentials Credentials { get; set; }
	public string ReturnUrl { get; set; }
	[TempData] public string Email { get; set; }


	public Task<IActionResult> OnGet(string? email, string? returnUrl = null)
	{
		ReturnUrl = returnUrl ?? Url.Content("~/");
		// doing 2 extra email validations in case somebody tries to access this page by writing an email in the url
		if (email == null || _validatable.ValidateEmail(email) == false)
		{
			_logger.LogWarning("{PageName} => Provided email {EmailAddress} is null or invalid. {Date}", "RegisterPersonalInfo Page", email, DateTime.UtcNow.ToString("dd/MM/yyyy HH:mm:ss"));
			_toastNotification.AddErrorToastMessage("Access Denied");
			return Task.FromResult<IActionResult>(RedirectToPage("../AccessDenied"));
		}

		if (_personService.IsPersonAlreadyRegistered(email))
		{
			_logger.LogWarning("{PageName} => {EmailAddress} was used to register personal information for a person a second time. {Date}", "RegisterPersonalInfo Page", email, DateTime.UtcNow.ToString("dd/MM/yyyy HH:mm:ss"));
			_toastNotification.AddErrorToastMessage("Please try to login with provided email.");
			return Task.FromResult<IActionResult>(RedirectToPage("./Login"));
		}

		Email = email;
		TempData["Email"] = email;
		try
		{
			Credentials = new Credentials().ReadCredentialsByEmail(_credentialsService, TempData.Peek("Email")!.ToString()!);
			TempData.Keep("Email");
			TempData.Set("Credentials", new SerializableCredentials().Map(Credentials));
			TempData.Keep("Credentials");
		}
		catch (DataAccessException e)
		{
			_logger.LogWarning("{PageName} => Provided email {EmailAddress} is not found in the database. {Date}", "RegisterPersonalInfo Page", Email, DateTime.UtcNow.ToString("dd/MM/yyyy HH:mm:ss"));
			_toastNotification.AddErrorToastMessage(e.Message);
			return Task.FromResult<IActionResult>(RedirectToPage("/AccessDenied"));
		}
		catch (Exception)
		{
			_toastNotification.AddErrorToastMessage("Something went wrong");
			return Task.FromResult<IActionResult>(RedirectToPage(""));
		}

		return Task.FromResult<IActionResult>(Page());
	}

	public Task<IActionResult> OnPost()
	{
		if (!ModelState.IsValid) return Task.FromResult<IActionResult>(Page());
		var email = TempData.Peek("Email")!.ToString()!;
		var userCredentials = TempData.Get<SerializableCredentials>("Credentials");
		var person = new Person(userCredentials.Map(), Person.FirstName, Person.LastName, Person.PhoneNumber,null, new Customer());

		try
		{
			var result = person.CreatePerson(_personService);
			if (!result)
				return Task.FromResult<IActionResult>(Page());
		}
		catch (DataAccessException data)
		{
			_logger.LogWarning("{PageName} => {Exception}, {Date}", "RegisterPersonalInfo Page", data.Message, DateTime.UtcNow.ToString("dd/MM/yyyy HH:mm:ss"));
			_toastNotification.AddErrorToastMessage(data.Message);
			return Task.FromResult<IActionResult>(Page());
		}
		catch (Exception e)
		{
			_logger.LogWarning("{PageName} => {Exception}, {Date}", "RegisterPersonalInfo Page", e.Message, DateTime.UtcNow.ToString("dd/MM/yyyy HH:mm:ss"));
			_toastNotification.AddErrorToastMessage(e.Message);
		}

		_logger.LogInformation("{PageName} => Person successfully created for {Email}", "RegisterPersonalInfo Page", Email);
		_toastNotification.AddSuccessToastMessage("Account created successfully");
		return Task.FromResult<IActionResult>(RedirectToPage("./RegistrationConfirmation"));
	}
}