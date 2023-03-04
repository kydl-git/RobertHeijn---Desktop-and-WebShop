using System.Security.Claims;
using BusinessLogic.BL_Classes;
using BusinessLogic.BL_DaL_Interfaces;
using BusinessLogic.BL_Validation;
using BusinessLogic.Data_Exceptions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using RobertHeijn_Web_App.Models.Account;

namespace RobertHeijn_Web_App.Controllers;

[Authorize]
[Route("[controller]/[action]")]
public class AccountController : Controller
{
	private readonly IToastNotification _toastNotification;
	private readonly ICredentialsActionable _credentialsService;
	private readonly ILogger<AccountController> _logger;
	private readonly IPersonActionable _personService;
	private readonly IValidatable _validation;
	
	public AccountController(IToastNotification toastNotification, ICredentialsActionable credentialsService, ILogger<AccountController> logger, IPersonActionable personService, IValidatable validation)
	{
		_toastNotification = toastNotification;
		_credentialsService = credentialsService;
		_logger = logger;
		_personService = personService;
		_validation = validation;
	}
	[TempData] public string StatusMessage { get; set; }
	[HttpGet]
	public Task<IActionResult> MyAccount()
	{
		AccountViewModel? model = null;
		try
		{
			Person person = new Person(new Credentials().ReadCredentialsByEmail(_credentialsService,HttpContext.User.FindFirstValue(ClaimTypes.Email)));
			person = person.GetPerson(_personService);
			model = new AccountViewModel
			{
				Email = person.Credentials.Email,
				FirstName = person.FirstName,
				LastName = person.LastName,
				Phone = person.Phone,
				Role = person.Role!.GetType().Name,
				StatusMessage = StatusMessage
			};
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

	[HttpGet]
	public Task<IActionResult> EditAccount()
	{
		Person person;
		try
		{
			person = new Person(new Credentials().ReadCredentialsByEmail(_credentialsService,HttpContext.User.FindFirstValue(ClaimTypes.Email)));
			person = person.GetPerson(_personService);
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
			return Task.FromResult<IActionResult>(RedirectToPage("/Index"));
		}
		var model = new EditDetailsModel
		{ 
			Email = person.Credentials.Email,
			PhoneNumber = person.Phone!,
			StatusMessage = StatusMessage
		};
		return Task.FromResult<IActionResult>(View(model));
	}

	[HttpPost]
	[ValidateAntiForgeryToken]
	public async Task<IActionResult> EditAccount(EditDetailsModel model)
	{
		if (!ModelState.IsValid)
		{
			return View(model);
		}

		if (!_validation.ValidateEmail(model.Email!))
		{
			_logger.LogError("{PageName} => Invalid email: {Email} provided at {DateTimeNow}", "Email Edit Page", model.Email, DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
			_toastNotification.AddErrorToastMessage("Invalid email");
			return View(model);
		}

		try
		{
			Person person = new(new Credentials().ReadCredentialsByEmail(_credentialsService,HttpContext.User.FindFirstValue(ClaimTypes.Email)));
			person = person.GetPerson(_personService);
			
			var email = person.Credentials.Email;
			if(model.Email != email)
			{
				var setEmailResult = person.Credentials.UpdateEmail(_credentialsService, model.Email!);
				if (!setEmailResult)
				{
					_toastNotification.AddErrorToastMessage("Something went wrong");
				}
				var identity = HttpContext.User.Identities.FirstOrDefault(c => c.IsAuthenticated);
				if(HttpContext.User!.HasClaim(claim => claim.Type == ClaimTypes.Email))
					identity!.RemoveClaim(HttpContext.User!.FindFirst(claim => claim.Value == email));
				identity!.AddClaim(new Claim(ClaimTypes.Email, model.Email!));
				var authProperties = new AuthenticationProperties
				{
					AllowRefresh = true,
					IsPersistent = true,
					ExpiresUtc = DateTimeOffset.UtcNow.AddDays(10)
				};
				await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity), authProperties);
			}
			var phone = person.Phone;
			if(model.PhoneNumber != phone)
			{
				var setPhoneResult = person.UpdatePhone(_personService, model.PhoneNumber!);
				if (!setPhoneResult)
				{
					_toastNotification.AddErrorToastMessage("Something went wrong");
					return RedirectToPage("/Account/MyAccount");
				}
			}
		}
		catch (ConnectionUnavailableException con)
		{
			_toastNotification.AddErrorToastMessage(con.Message);
			_logger.LogWarning("{PageName} => {Exception}, {Date}", "MyAccount", con.Message, DateTime.UtcNow.ToString("dd/MM/yyyy HH:mm:ss"));
			return RedirectToPage("/Account/MyAccount");
		}
		catch(Exception e)
		{
			_toastNotification.AddErrorToastMessage("Something went wrong");
			_logger.LogWarning("{PageName} => {Exception}, {Date}", "MyAccount", e.Message, DateTime.UtcNow.ToString("dd/MM/yyyy HH:mm:ss"));
			return RedirectToPage("/Account/MyAccount");
		}
		StatusMessage = "Your profile has been updated";
		return RedirectToAction(nameof(MyAccount));
	}
	[HttpGet]
	public Task<IActionResult> ChangePassword()
	{
		try
		{
			Person person = new(new Credentials().ReadCredentialsByEmail(_credentialsService, HttpContext.User.FindFirstValue(ClaimTypes.Email)));
			person.GetPerson(_personService);
		}
		catch (ConnectionUnavailableException con)
		{
			_toastNotification.AddErrorToastMessage(con.Message);
			_logger.LogWarning("{PageName} => {Exception}, {Date}", "ChangePassword", con.Message, DateTime.UtcNow.ToString("dd/MM/yyyy HH:mm:ss"));
			return Task.FromResult<IActionResult>(RedirectToPage("/Index"));
		}
		catch (Exception e)
		{
			_toastNotification.AddErrorToastMessage("Something went wrong");
			_logger.LogWarning("{PageName} => {Exception}, {Date}", "ChangePassword", e.Message, DateTime.UtcNow.ToString("dd/MM/yyyy HH:mm:ss"));
			return Task.FromResult<IActionResult>(RedirectToPage("/Index"));
		}

		var model = new ChangePasswordViewModel { StatusMessage = StatusMessage };
		return Task.FromResult<IActionResult>(View(model));
	}

	[HttpPost]
	[ValidateAntiForgeryToken]
	public Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
	{
		if (!ModelState.IsValid)
		{
			return Task.FromResult<IActionResult>(View(model));
		}
		try
		{
			Person person = new(new Credentials().ReadCredentialsByEmail(_credentialsService, HttpContext.User.FindFirstValue(ClaimTypes.Email)));
			person = person.GetPerson(_personService);
			var changePasswordResult = person.Credentials.UpdatePassword(_credentialsService, model.OldPassword, model.NewPassword);
			if (!changePasswordResult)
			{
				ModelState.AddModelError(string.Empty, "Password change failed");
				return Task.FromResult<IActionResult>(View(model));
			}
			_logger.LogInformation("User changed their password successfully");
			StatusMessage = "Your password has been changed.";
		}
		catch (ConnectionUnavailableException con)
		{
			_toastNotification.AddErrorToastMessage(con.Message);
			_logger.LogWarning("{PageName} => {Exception}, {Date}", "ChangePassword", con.Message, DateTime.UtcNow.ToString("dd/MM/yyyy HH:mm:ss"));
			return Task.FromResult<IActionResult>(RedirectToPage("/Index"));
		}
		catch (Exception e)
		{
			_toastNotification.AddErrorToastMessage("Something went wrong");
			_logger.LogWarning("{PageName} => {Exception}, {Date}", "ChangePassword", e.Message, DateTime.UtcNow.ToString("dd/MM/yyyy HH:mm:ss"));
			return Task.FromResult<IActionResult>(RedirectToPage("/Index"));
		}

		return Task.FromResult<IActionResult>(RedirectToAction(nameof(ChangePassword)));
	}
	
}