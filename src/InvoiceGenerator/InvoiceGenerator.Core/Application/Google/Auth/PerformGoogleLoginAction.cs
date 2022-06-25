using System.Security.Claims;
using Google.Apis.Auth.AspNetCore3;
using InvoiceGenerator.Core.Models.Auth;
using InvoiceGenerator.Core.Models.Google.Auth;
using InvoiceGenerator.Core.Services.Google.Application.Auth;
using InvoiceGenerator.Core.Services.Google.Auth;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;

namespace InvoiceGenerator.Core.Application.Google.Auth;

public class PerformGoogleLoginAction : IPerformGoogleLoginAction
{
    private readonly HttpContext _httpContext;
    private readonly IGoogleConfiguration _configuration;
    private readonly IGoogleTokenHttpClient _tokenHttpClient;

    public PerformGoogleLoginAction (
        IHttpContextAccessor httpContextAccessor,
        IGoogleConfiguration googleConfiguration,
        IGoogleTokenHttpClient googleTokenHttpClient)
    {
        _httpContext = httpContextAccessor.HttpContext;
        _configuration = googleConfiguration;
        _tokenHttpClient = googleTokenHttpClient;
    }
    
    public async Task<PerformGoogleLoginActionResponse> Login(string code, string scope, string authuser, string prompt)
    {
        if (!prompt.Equals("consent"))
            return PerformGoogleLoginActionResponse.NoConsent;

        if (!ValidateScopes(scope))
            return PerformGoogleLoginActionResponse.BadScopes;

        var tokenResponse = await _tokenHttpClient.GetToken(code);
        if (tokenResponse == null)
            return PerformGoogleLoginActionResponse.UnknownError;

        var user = await _tokenHttpClient.GetUserInformations();
        if (user == null)
            return PerformGoogleLoginActionResponse.UnknownError;

        var authUser = new AuthUser
        {
            FullName = user.FullName,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            PictureUrl = user.Picture,
            AccessToken = tokenResponse.AccessToken,
            RefreshToken = tokenResponse.RefreshToken,
        };
        
        var claimsIdentity = new ClaimsIdentity(authUser.GetClaims(), GoogleOpenIdConnectDefaults.AuthenticationScheme);
        var authProperties = new AuthenticationProperties { IsPersistent = true };

        try
        {
            await _httpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);
            return PerformGoogleLoginActionResponse.Ok;
        }
        catch
        {
            return PerformGoogleLoginActionResponse.UnknownError;
        }
    }
    
    private bool ValidateScopes(string scopes)
    {
        var scopeList =  scopes.Split(' ');
        foreach (var scope in _configuration.ScopesWithBase)
        {
            if(!scope.Contains(_configuration.ApiBaseUrl))
                continue;

            if (!scopeList.Contains(scope))
                return false;
        }

        return true;
    }
}