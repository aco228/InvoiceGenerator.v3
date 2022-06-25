namespace InvoiceGenerator.Core.Services.Google.Auth;

public interface IGoogleRedirectionService
{
    string GetAuthRedirectionUrl();
}