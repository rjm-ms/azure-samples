using Azure.Identity;
using Microsoft.Graph;

internal class Program
{
    private static async Task Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        var scopes = new[] { "https://graph.microsoft.com/.default" };

        // Get the application ID and secret from the Azure portal.
        string clientId = "f46c72c2-8427-4586-9a33-731d3cc94fc6";
        string clientSecret = "IVA8Q~ruAhKoPtcAQ4gE~x2n~N88w8b_O9aCEaE-";
        string tenantId = "cc03c53b-d42a-4b60-a921-81175fb6d4f9";

        // using Azure.Identity
        var options = new TokenCredentialOptions
        {
            AuthorityHost = AzureAuthorityHosts.AzurePublicCloud
        };

        var clientSecretCredential = new ClientSecretCredential(tenantId, clientId, clientSecret, options);
        var graphClient = new GraphServiceClient(clientSecretCredential, scopes);

        var users = await graphClient.Users.GetAsync();

        foreach (var user in users.Value)
        {
            Console.WriteLine($"{user.DisplayName}, {user.GivenName}");
        }
    }
}