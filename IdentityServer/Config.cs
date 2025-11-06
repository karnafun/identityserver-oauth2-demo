using Duende.IdentityServer.Models;

namespace IdentityServer
{
    public static class Config
    {
        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                new Client
                    {
                        ClientId = "demo-client",
                        AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                        ClientSecrets = { new Secret("demo-secret".Sha256()) },
                        AllowedScopes = { "api.read" }
                    }
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope> { new ApiScope("api.read", "Read Access to API") };

        public static IEnumerable<ApiResource> ApiResources =>
            new List<ApiResource>
            {
                new ApiResource("api-demo", "API Demo")
                {
                    Scopes = { "api.read" }
                }
            };
    }
}
