namespace InvoiceGenerator.Core.Services.Google.Auth;

public interface IGoogleConfiguration
{
    public string? ClientId {get;}
    public string? ProjectId {get;}
    public string? ClientSecret {get;}
    public string? AuthUri {get;}
    public string? TokenUri {get;}
    public string? AuthProviderCertUri {get;}
    public string? ApiBaseUrl { get; }
    public string RedirectUrl { get; }
    public List<string>? Scopes { get; }
    public List<string> ScopesWithBase { get; }
}