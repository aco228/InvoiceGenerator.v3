using Newtonsoft.Json;

namespace InvoiceGenerator.Core.Models.Google.Auth;

public record GetUserInformationsResponse
{
    [JsonProperty("email")]
    public string Email { get; set; }
    
    [JsonProperty("name")]
    public string FullName { get; set; }
    
    [JsonProperty("given_name")]
    public string FirstName { get; set; }
    
    [JsonProperty("family_name")]
    public string LastName { get; set; }
    
    [JsonProperty("picture")]
    public string Picture { get; set; }
    
}