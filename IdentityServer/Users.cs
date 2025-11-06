using Duende.IdentityServer.Test;

namespace IdentityServer
{   
    public static class Users
    {
        public static List<TestUser> Get()
        {
            return new List<TestUser>
        {
            new TestUser
            {
                SubjectId = "1",          // unique ID for the user
                Username = "demo",        // what you type to login
                Password = "password",    // simple password for demo
                Claims = new[]
                {
                    new System.Security.Claims.Claim("name", "Demo User"),
                    new System.Security.Claims.Claim("role", "Admin")
                }
            }
        };
        }
    }

}
