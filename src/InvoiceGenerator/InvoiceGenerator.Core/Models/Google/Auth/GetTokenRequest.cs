using Newtonsoft.Json;

namespace InvoiceGenerator.Core.Models.Google.Auth;

public class GetTokenRequest
{
    [JsonProperty("code")]
    public string Code { get; set; }
    
    [JsonProperty("client_id")]
    public string ClientId { get; set; }
    
    [JsonProperty("client_secret")]
    public string ClientSecret { get; set; }
    
    [JsonProperty("redirect_uri")]
    public string RedirectUrl { get; set; }
    
    [JsonProperty("grant_type")]
    public string GrantType { get; set; }
}