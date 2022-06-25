using Aco228.SimpleHttpClient;
using InvoiceGenerator.Core.Models.Google.Auth;
using InvoiceGenerator.Core.Services.Google.Auth;

namespace InvoiceGenerator.Core.Infrastructure.Google.Auth;

public class GoogleTokenHttpClient : IGoogleTokenHttpClient
{
    private readonly IGoogleConfiguration _configuration;
    private readonly IRequestClient _requestClient;

    public GoogleTokenHttpClient (IGoogleConfiguration configuration)
    {
        _configuration = configuration;
        _requestClient = new RequestClient();
    }

    public async Task<GetTokenResponse?> GetToken(string code)
    {
        var request = new GetTokenRequest
        {
            Code = code,
            ClientId = _configuration.ClientId,
            ClientSecret = _configuration.ClientSecret,
            RedirectUrl = _configuration.RedirectUrl,
            GrantType = "authorization_code",
        };
        

        var tokenResponse = await _requestClient.Post<GetTokenResponse?>(_configuration.TokenUri, request);
        _requestClient.AddAuthorization(tokenResponse.AccessToken);
        return tokenResponse;
    }

    public Task<GetUserInformationsResponse?> GetUserInformations()
        => _requestClient.Get<GetUserInformationsResponse?>( _configuration.ApiBaseUrl + "oauth2/v2/userinfo");
}