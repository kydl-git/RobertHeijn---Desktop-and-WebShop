#region

using System.Security.Claims;
using BusinessLogic.BL_Classes;
using BusinessLogic.BL_DaL_Interfaces;
using BusinessLogic.BL_Managers;
using BusinessLogic.BL_Validation;
using BusinessLogic.Data_Exceptions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NToastNotify;
using RobertHeijn_Web_App.Models.Account;

#endregion

namespace RobertHeijn_Web_App.Areas.Identity.Pages.Account;

[AllowAnonymous]
public class LoginModel : PageModel
{
    private readonly ICredentialsActionable _credentialsService;
    private readonly ILogger<LoginModel> _logger;
    private readonly IPersonActionable _personService;
    private readonly IShoppingCartActionable _shoppingCartService;
    private readonly IToastNotification _toastNotification;
    private readonly IValidatable _validation;

    public LoginModel(IToastNotification toastNotification, ICredentialsActionable credentialsService, IPersonActionable personService, IShoppingCartActionable shoppingCartService, ILogger<LoginModel> logger, IValidatable validation)
    {
        _toastNotification = toastNotification;
        _credentialsService = credentialsService;
        _personService = personService;
        _shoppingCartService = shoppingCartService;
        _logger = logger;
        _validation = validation;
    }

    [BindProperty] public LoginInputModel Input { get; set; }

    public string? ReturnUrl { get; set; }

    [TempData] public string? ErrorMessage { get; set; }

    public async Task OnGet(string? returnUrl = null)
    {
        if (!string.IsNullOrEmpty(ErrorMessage))
        {
            _toastNotification.AddErrorToastMessage(ErrorMessage);
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            ModelState.AddModelError(string.Empty, ErrorMessage);
        }

        returnUrl ??= Url.Content("~/");
        ReturnUrl = returnUrl;
    }

    public async Task<IActionResult> OnPost(string? returnUrl = null)
    {
        returnUrl ??= Url.Content("~/");
        if (!ModelState.IsValid) return Page();
        if (!_validation.ValidateEmail(Input.Email))
        {
            _logger.LogInformation("{PageName} => Invalid email: {InputEmail}, {DateTimeNow}", "Login Page", Input.Email, DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
            _toastNotification.AddErrorToastMessage("Invalid email");
            ErrorMessage = "Invalid email";
            return Page();
        }

        try
        {
            var credentials = new Credentials(Input.Email, Input.Password);
            var user = credentials.Login(_credentialsService);
            if (user == null)
            {
                _logger.LogInformation("{PageName} => Provided email: {InputEmail} does not match provided password, {DateTimeNow}", "Login Page", Input.Email, DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
                _toastNotification.AddErrorToastMessage("Invalid credentials");
                return Page();
            }

            Person person = new(user);
            person = person.GetPerson(_personService);
            var claims = new List<Claim>
            {
                new(ClaimTypes.Email, user.Email),
                new(ClaimTypes.Name, person.FirstName!),
                new(ClaimTypes.NameIdentifier, person.Id.ToString()!),
                new(ClaimTypes.Role, person.Role!.GetType().Name),
                new(ClaimTypes.Surname, person.LastName!)
            };
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties
            {
                AllowRefresh = true,
                IsPersistent = Input.RememberMe,
                ExpiresUtc = DateTimeOffset.UtcNow.AddDays(10)
            };
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);
            _toastNotification.AddSuccessToastMessage($"Welcome back {person.FirstName}!");
            TransferAnonymousCartToUser(user.Email);
            return LocalRedirect(returnUrl);
        }
        catch (ConnectionUnavailableException con)
        {
            _logger.LogCritical("{PageName} => {Error}, {DateTimeNow}", "Login Page", con.Message, DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
            _toastNotification.AddErrorToastMessage($"{con.Message}");
            return RedirectToPage("/Index");
        }
        catch (NoDataFoundException ndf)
        {
            _logger.LogDebug("{PageName} => {Error}, {Email}, {DateTimeNow}", "Login Page", ndf.Message, Input.Email ,DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
            _toastNotification.AddErrorToastMessage($"Invalid credentials.");
            return RedirectToPage("/Index");
        }
        catch (Exception e)
        {
            //log the error but don't show it to the user. User should not know what went wrong, but for debugging purposes it is useful for us to know.
            _logger.LogDebug("{PageName} => {Error}, {DateTimeNow}", "Login Page", e.Message, DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
            _toastNotification.AddErrorToastMessage(@"An error occurred. Please try again later.");
            return RedirectToPage("/Index");
        }
    }

    private void TransferAnonymousCartToUser(string? email)
    {
        if (!Request.Cookies.ContainsKey(Constants.CartCookieName)) return;
        var cartId = Request.Cookies[Constants.CartCookieName];
        if (int.TryParse(cartId, out var id))
        {
            new ShoppingCart().TransferAnonymousCartToUser(_shoppingCartService, id, email);
            _logger.LogInformation("{PageName} => Anonymous shopping cart {Cart} transferred to user {Email}, {DateTimeNow}", "Login Page", cartId, email, DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
        }

        Response.Cookies.Delete(Constants.CartCookieName);
    }
}