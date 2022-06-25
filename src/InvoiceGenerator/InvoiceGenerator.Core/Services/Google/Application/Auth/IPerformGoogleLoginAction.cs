using InvoiceGenerator.Core.Application.Google.Auth;
using InvoiceGenerator.Core.Models.Google.Auth;

namespace InvoiceGenerator.Core.Services.Google.Application.Auth;

public interface IPerformGoogleLoginAction
{
    Task<PerformGoogleLoginActionResponse> Login(string code, string scope, string authuser, string prompt);
}