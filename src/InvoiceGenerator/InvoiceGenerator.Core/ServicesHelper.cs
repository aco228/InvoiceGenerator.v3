using InvoiceGenerator.Core.Application.Google.Auth;
using InvoiceGenerator.Core.Infrastructure.Auth;
using InvoiceGenerator.Core.Infrastructure.Google.Auth;
using InvoiceGenerator.Core.Services.Auth;
using InvoiceGenerator.Core.Services.Google.Application.Auth;
using InvoiceGenerator.Core.Services.Google.Auth;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.DependencyInjection;

namespace InvoiceGenerator.Core;

public static class ServicesHelper
{
    public static void RegisterGoogleServices(this IServiceCollection service)
    {
        service.AddTransient<IGoogleRedirectionService, GoogleRedirectionService>();
        service.AddSingleton<IGoogleConfiguration, GoogleConfiguration>();
        service.AddTransient<IPerformGoogleLoginAction, PerformGoogleLoginAction>();
        service.AddTransient<IGoogleTokenHttpClient, GoogleTokenHttpClient>();
    }

    public static void RegisterAuthentication(this IServiceCollection service)
    {
        service.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.Cookie.Name = "_auth";
                options.ExpireTimeSpan = TimeSpan.FromDays(15);
                options.SlidingExpiration = false;
            });
        
        service.AddTransient<IAuthProvider, AuthProvider>();
    }
}