using InvoiceGenerator.Core.Services.Google.Auth;
using Microsoft.Extensions.Configuration;

namespace InvoiceGenerator.Core.Infrastructure.Google.Auth;

public class GoogleConfiguration : IGoogleConfiguration
{
    private readonly IConfigurationSection _section;
    
    public GoogleConfiguration (IConfiguration configuration)
    {
        _section = configuration.GetSection("Google");
    }

    public string? ClientId => _section.GetValue<string>("ClientId");
    public string? ProjectId => _section.GetValue<string>("ProjectId");
    public string? ClientSecret => _section.GetValue<string>("ClientSecret");
    public string? AuthUri => _section.GetValue<string>("AuthUri");
    public string? TokenUri => _section.GetValue<string>("TokenUri");
    public string? AuthProviderCertUri => _section.GetValue<string>("AuthProviderCertUri");
    public string? ApiBaseUrl => _section.GetValue<string>("ScopeBaseUrl");
    public string RedirectUrl { get; } = "https://localhost:7121/GoogleCallback";

    public List<string>? Scopes => _section.GetSection("Scopes").Get<List<string>>(); //GetValue<List<string>>("Scopes");

    public List<string> ScopesWithBase
    {
        get
        {
            if (Scopes == null || Scopes.Count == 0)
                return new();


            var result = new List<string>();
            foreach (var scope in Scopes)
                if (scope.StartsWith("..."))
                    result.Add(ApiBaseUrl + scope.Substring(4));
                else
                    result.Add(scope);

            return result;
        }
    }
}