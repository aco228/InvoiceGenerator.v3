using InvoiceGenerator.Core.Models.Google.Auth;

namespace InvoiceGenerator.Core.Services.Google.Auth;

public interface IGoogleTokenHttpClient
{
    Task<GetTokenResponse?> GetToken(string code);
    Task<GetUserInformationsResponse?> GetUserInformations();
}