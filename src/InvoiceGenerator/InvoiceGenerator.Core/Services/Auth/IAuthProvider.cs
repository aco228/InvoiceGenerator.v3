using InvoiceGenerator.Core.Models.Auth;

namespace InvoiceGenerator.Core.Services.Auth;

public interface IAuthProvider
{
    AuthUser? GetUser();
}