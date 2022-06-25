using InvoiceGenerator.Core.Models.Google.Auth;
using InvoiceGenerator.Core.Services.Google.Application.Auth;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceGenerator.Controllers;

public class GoogleCallbackController : ControllerBase
{
    private readonly IPerformGoogleLoginAction _performLogin;
    
    public GoogleCallbackController (IPerformGoogleLoginAction performGoogleLoginAction)
    {
        _performLogin = performGoogleLoginAction;
    }
    
    public async Task<ActionResult> Index(string code, string scope, string authuser, string prompt)
    {
        var result = await _performLogin.Login(code, scope, authuser, prompt);
        if (result == PerformGoogleLoginActionResponse.UnknownError)
            return Redirect("/?error=unknown_error");
        
        if (result == PerformGoogleLoginActionResponse.NoConsent)
            return Redirect("/?error=no_consent");

        if (result == PerformGoogleLoginActionResponse.BadScopes)
            return Redirect("/?error=bad_scope");
        
        return Redirect("/");
    }
    
    public ActionResult Test()
    {
        return Content("OK");
    }
}