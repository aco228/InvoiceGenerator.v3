using InvoiceGenerator.Core.Services.Google.Auth;

namespace InvoiceGenerator.Core.Infrastructure.Google.Auth;

public class GoogleRedirectionService : IGoogleRedirectionService
{
    private readonly IGoogleConfiguration _configuration;
    
    public GoogleRedirectionService (IGoogleConfiguration googleConfiguration)
    {
        _configuration = googleConfiguration;
    }
    
    public string GetAuthRedirectionUrl()
    {
        var responseType = "code";
        var accessType = "offline";
        
        var result = $"{_configuration.AuthUri}" 
                     + $"?client_id={_configuration.ClientId}"
                     + $"&redirect_uri={_configuration.RedirectUrl}"
                     + $"&response_type={responseType}"
                     + $"&scope={GetScopes()}"
                     + $"&access_type={accessType}";

        return result;
    }

    private string GetScopes()
    {
        return string.Join(" ", _configuration.ScopesWithBase);
    }
}