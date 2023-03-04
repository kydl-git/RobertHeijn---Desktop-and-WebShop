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
using RobertHeijn_Web_App.Models.Account;

#endregion

namespace RobertHeijn_Web_App.Areas.Identity.Pages.Account;
[AllowAnonymous]
public class RegisterModel : PageModel
{
    private readonly CredentialsService _credentialsService;
    private readonly ILogger<RegisterModel> _logger;
    private readonly PersonService _personService;
    private readonly IToastNotification _toastNotification;
    private readonly IValidatable _validation;

    public RegisterModel(ICredentialsActionable credentialsService, IPersonActionable personService, ILogger<RegisterModel> logger, IToastNotification toastNotification, IValidatable validation)
    {
        _credentialsService = (CredentialsService)credentialsService;
        _personService = (PersonService)personService;
        _logger = logger;
        _toastNotification = toastNotification;
        _validation = validation;
    }

    [BindProperty] public RegisterInputModel RegisterInput { get; set; }
    [TempData] public string? ErrorMessage { get; set; }

    public string? ReturnUrl { get; set; }

    public void OnGet(string? returnUrl = null)
    {
        ReturnUrl = returnUrl;
    }

    public IActionResult OnPost(string? returnUrl = null)
    {
        returnUrl = returnUrl ?? Url.Content("~/");
        if (!ModelState.IsValid) return Page();
        if (!_validation.ValidateEmail(RegisterInput.Email))
        {
            _logger.LogError("{PageName} => Invalid email: {RegisterInputEmail} provided at {DateTimeNow}", "Register Page", RegisterInput.Email, DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
            _toastNotification.AddErrorToastMessage("Invalid email", new ToastrOptions
            {
                ProgressBar = false,
                CloseButton = false,
                TimeOut = 4500,
                PositionClass = ToastPositions.BottomCenter,
                NewestOnTop = true
            });
            ErrorMessage = "Invalid email";
            return Page();
        }

        try
        {
            if (!_validation.CheckEmailDuplicate(_credentialsService, RegisterInput.Email))
            {
                _logger.LogCritical("{PageName} => Duplicate email: {RegisterInputEmail} provided at {DateTimeNow}", "Register Page", RegisterInput.Email, DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
                _toastNotification.AddErrorToastMessage("Email already exists");
                ErrorMessage = "Email already exists";
                return Page();
            }
        }
        catch (DataAccessException e)
        {
            _logger.LogError("{PageName} => {Exception}, {Date}", "Register Page", e.Message, DateTime.UtcNow.ToString("dd/MM/yyyy HH:mm:ss"));
            _toastNotification.AddErrorToastMessage(e.Message);
        }

        var user = new Credentials(RegisterInput.Email, RegisterInput.Password, true);
        try
        {
            var result = user.Create(_credentialsService);
            if (!result) return Page();
        }
        catch (DataAccessException data)
        {
            _logger.LogError("{PageName} => {Exception}, {Date}", "Register Page", data.Message, DateTime.UtcNow.ToString("dd/MM/yyyy HH:mm:ss"));
            _toastNotification.AddErrorToastMessage(data.Message);
            return Page();
        }
        catch (Exception e)
        {
            _logger.LogError("{PageName} => {Exception}, {Date}", "Register Page", e.Message, DateTime.UtcNow.ToString("dd/MM/yyyy HH:mm:ss"));
            _toastNotification.AddErrorToastMessage(e.Message);
        }

        _logger.LogInformation("{PageName} => New user created with {Email}", "Register Page", RegisterInput.Email);
        _toastNotification.AddSuccessToastMessage("Account created successfully");
        return RedirectToPage("./RegisterPersonalInfo", new { RegisterInput.Email });
    }
}