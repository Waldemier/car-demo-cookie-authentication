using System.Globalization;
using System.Security.Claims;
using Car.Demo.DLL.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Car.Demo.Security;

public class SecurityService : ISecurityService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public SecurityService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public string? GetCurrentUserId() => 
        _httpContextAccessor.HttpContext!.User.Claims.SingleOrDefault(x => x.Type.Equals("Id"))?.Value;

    public async Task Authenticate(User user)
    {
        var claims = new List<Claim>()
        {
            new Claim("Id", user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.Email!),
            new Claim(ClaimTypes.Role, user.Role.ToString()),
            new Claim(ClaimTypes.MobilePhone, user.PhoneNumber!),
            new Claim("LastChanged", user.LastChanged.ToString(CultureInfo.InvariantCulture))
        };

        var identity = new ClaimsIdentity(claims,
            CookieAuthenticationDefaults.AuthenticationScheme,
            ClaimTypes.Name,
            ClaimTypes.Role);

        await _httpContextAccessor.HttpContext!.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(identity), 
            new AuthenticationProperties()
            {
                // IsPersistent = true,
                // AllowRefresh = true, // Refreshed by each request
                // IssuedUtc = DateTime.UtcNow,
                // RedirectUri = "https://localhost:7159/api/car/all-cars"
            });
    }

    public async Task SignOut() => 
        await _httpContextAccessor.HttpContext!.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
}