using Aco228.SimpleHttpClient;
using InvoiceGenerator.Core.Services.Google;
using InvoiceGenerator.Core.Services.Google.Auth;

namespace InvoiceGenerator.Core.Infrastructure.Google;

public class GoogleRequestClient : RequestClient, IGoogleRequestClient
{
    public GoogleRequestClient (IGoogleConfiguration googleConfiguration)
    {
        
    }
    
    
}