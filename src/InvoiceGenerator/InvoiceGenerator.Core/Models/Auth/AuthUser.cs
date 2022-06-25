using System.Security.Claims;

namespace InvoiceGenerator.Core.Models.Auth;

public class AuthUser
{
    public string FullName {get;set;}
    public string FirstName {get;set;}
    public string LastName {get;set;}
    public string Email {get;set;}
    public string PictureUrl {get;set;}
    public string AccessToken {get;set;}
    public string RefreshToken {get;set;}

    public List<Claim> GetClaims()
        => new()
        {
            new(AuthClaims.FullName, FullName),
            new(AuthClaims.FirstName, FirstName),
            new(AuthClaims.LastName, LastName),
            new(AuthClaims.Email, Email),
            new(AuthClaims.PictureUrl, PictureUrl),
            new(AuthClaims.AccessToken, AccessToken),
            new(AuthClaims.RefreshToken, RefreshToken),
        };

    public static AuthUser GetUserFromClaims(List<Claim> claims)
        => new ()
        {
            FullName = claims.FirstOrDefault(x => x.Type == AuthClaims.FullName)?.Value ?? string.Empty,
            FirstName = claims.FirstOrDefault(x => x.Type == AuthClaims.FirstName)?.Value ?? string.Empty,
            LastName = claims.FirstOrDefault(x => x.Type == AuthClaims.LastName)?.Value ?? string.Empty,
            Email = claims.FirstOrDefault(x => x.Type == AuthClaims.Email)?.Value ?? string.Empty,
            PictureUrl = claims.FirstOrDefault(x => x.Type == AuthClaims.PictureUrl)?.Value ?? string.Empty,
            AccessToken = claims.FirstOrDefault(x => x.Type == AuthClaims.AccessToken)?.Value ?? string.Empty,
            RefreshToken = claims.FirstOrDefault(x => x.Type == AuthClaims.RefreshToken)?.Value ?? string.Empty,
        };
}