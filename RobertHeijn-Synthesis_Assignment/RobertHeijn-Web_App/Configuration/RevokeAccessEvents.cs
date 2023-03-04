#region

using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Caching.Memory;

#endregion

namespace RobertHeijn_Web_App.Configuration;

public class RevokeAccessEvents : CookieAuthenticationEvents
{
    private readonly IMemoryCache _cache;
    private readonly ILogger _logger;

    public RevokeAccessEvents(IMemoryCache cache, ILogger<RevokeAccessEvents> logger)
    {
        _cache = cache;
        _logger = logger;
    }

    public override async Task ValidatePrincipal(CookieValidatePrincipalContext context)
    {
        var userId = context.Principal?.Claims.First(c => c.Type == ClaimTypes.NameIdentifier);
        var identityKey = context.Request.Cookies[ApplicationCookiesConstants.IdentifierCookieName];
        if (_cache.TryGetValue($"{userId}:{identityKey}", out var revoked) && (bool)revoked)
        {
            _logger.LogDebug("Access has been revoked for: {UserId}", userId);
            context.RejectPrincipal();
            await context.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }
    }
}