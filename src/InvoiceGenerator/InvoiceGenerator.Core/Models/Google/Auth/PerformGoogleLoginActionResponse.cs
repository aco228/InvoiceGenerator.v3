namespace InvoiceGenerator.Core.Models.Google.Auth;

public enum PerformGoogleLoginActionResponse
{
    UnknownError,
    NoConsent,
    BadScopes,
    Ok,
}