#region

using System.Security.Claims;
using BusinessLogic.BL_DaL_Interfaces;
using BusinessLogic.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;
using NToastNotify;
using RobertHeijn_Web_App.Configuration;

#endregion

namespace RobertHeijn_Web_App.Areas.Identity.Pages.Account;

public class LogoutModel : PageModel
{
    private readonly IMemoryCache _cache;
    private readonly CredentialsService _credentialsService;
    private readonly ILogger<LogoutModel> _logger;
    private readonly IToastNotification _toastNotification;

    public LogoutModel(IMemoryCache cache, ILogger<LogoutModel> logger, ICredentialsActionable credentialsInterface, IToastNotification toastNotification)
    {
        _cache = cache;
        _logger = logger;
        _credentialsService = (CredentialsService)credentialsInterface;
        _toastNotification = toastNotification;
    }

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync(string? returnUrl = null)
    {
        if (HttpContext.User.Identity?.IsAuthenticated != true) return RedirectToPage("/Account/Login");
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        var userId = HttpContext.User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier);
        var identityKey = HttpContext.Request.Cookies[ApplicationCookiesConstants.IdentifierCookieName];
        _cache.Set($"{userId.Value}:{identityKey}", identityKey, new MemoryCacheEntryOptions
        {
            Priority = CacheItemPriority.High,
            AbsoluteExpiration = DateTime.Now.AddMinutes(ApplicationCookiesConstants.ValidityMinutesPeriod)
        });
        _logger.LogInformation("{UserIdValue}:{IdentityKey}", userId.Value, identityKey);
        _logger.LogInformation("User {userId} logged out", userId.Value);
        if (returnUrl != null) return LocalRedirect(returnUrl);
        return RedirectToPage("/Index");
    }
}