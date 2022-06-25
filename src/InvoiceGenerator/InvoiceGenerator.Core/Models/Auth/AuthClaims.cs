namespace InvoiceGenerator.Core.Models.Auth;

public static class AuthClaims
{
    public static string FullName => "FullName";
    public static string FirstName => "FirstName";
    public static string LastName => "LastName";
    public static string Email => "Email";
    public static string PictureUrl => "PictureUrl";
    public static string AccessToken => "AccessToken";
    public static string RefreshToken => "RefreshToken";
}