using InvoiceGenerator.Core.Models.Auth;
using InvoiceGenerator.Core.Services.Auth;
using Microsoft.AspNetCore.Http;

namespace InvoiceGenerator.Core.Infrastructure.Auth;

public class AuthProvider : IAuthProvider
{
    private readonly IHttpContextAccessor _contextAccessor;
    
    public AuthProvider (IHttpContextAccessor contextAccessor)
    {
        _contextAccessor = contextAccessor;
    }

    public AuthUser? GetUser()
    {
        var user = _contextAccessor.HttpContext?.User;
        if (user == null)
            return null;

        return AuthUser.GetUserFromClaims(user.Claims.ToList());
    }
}