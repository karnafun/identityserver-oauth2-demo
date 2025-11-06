# OAuth2 Protected API with IdentityServer and ASP.NET Core

A complete OAuth2 demo showing how to protect an ASP.NET Core API using JWT tokens issued by Duende IdentityServer. The solution demonstrates token-based authentication from request to protected endpoint access.

## What This Demo Shows

* IdentityServer configuration for issuing OAuth2 tokens
* JWT token validation in ASP.NET Core API
* Protected endpoints requiring authentication
* Configuration validation using `IOptions<T>` pattern
* Error handling and HTTPS enforcement

## Prerequisites

* .NET 8.0 SDK
* Visual Studio 2022 or VS Code
* Duende IdentityServer (free for development)

## Project Structure

```
CSharp-API-OAuth2-Demo/
├── IdentityServer/          # Token issuer (port 5001)
│   ├── Config.cs           # Client, scope, resource definitions
│   ├── Users.cs            # Test user credentials
│   └── wwwroot/
│       └── test-token.html # Token request form
└── ApiDemo/                # Protected API (port 5002)
    ├── Controllers/
    │   └── UsersController.cs
    └── Configuration/
        └── IdentityServerOptions.cs
```

## Quick Start

### 1. Clone and Restore

```bash
git clone https://github.com/karnafun/CSharp-API-OAuth2-Demo.git
cd CSharp-API-OAuth2-Demo
dotnet restore
```

### 2. Run Both Projects

**Option A: Visual Studio**

* Open `CSharp-API-OAuth2-Demo.sln`
* Set both projects as startup projects, or run them separately
* IdentityServer runs on `https://localhost:5001`
* ApiDemo runs on `https://localhost:5002`

**Option B: Command Line**

```bash
# Terminal 1 - IdentityServer
cd IdentityServer
dotnet run

# Terminal 2 - ApiDemo
cd ApiDemo
dotnet run
```

### 3. Get a Token

Navigate to `https://localhost:5001/test-token.html` and use the pre-filled credentials:

* Username: `demo`
* Password: `password`
* Client ID: `demo-client`
* Client Secret: `demo-secret`
* Scope: `api.read`

Click "Get Token" and copy the `access_token` from the response.

### 4. Call the Protected API

**Using Swagger:**

1. Open `https://localhost:5002/swagger`
2. Click "Authorize"
3. Enter `Bearer <your-token>` and authorize
4. Call `GET /Users`

**Using curl:**

```bash
curl -H "Authorization: Bearer <your-token>" \
     https://localhost:5002/Users
```

**Expected response:**

```json
[
  {
    "name": "Demo User",
    "role": "Admin"
  }
]
```

**Without token (401 Unauthorized):**

```bash
curl https://localhost:5002/Users
```

## Configuration

The API reads the IdentityServer authority from `appsettings.json`:

```json
{
  "IdentityServer": {
    "Authority": "https://localhost:5001"
  }
}
```

Configuration is validated at startup. Missing values cause the application to fail immediately.

## Key Components

**IdentityServer (`Config.cs`):**

* Defines client credentials and allowed grant types
* Configures API scopes and resources
* Uses Resource Owner Password grant for demo simplicity

**API (`Program.cs`):**

* Validates JWT tokens using `JwtBearer` authentication
* Checks token audience matches `api-demo`
* Enforces HTTPS redirection

**Protected Endpoint (`UsersController.cs`):**

* Uses `[Authorize]` attribute to require valid tokens
* Returns 401 Unauthorized without authentication

## Grant Type Note

This demo uses Resource Owner Password grant for simplicity. Production applications should use:

* **Authorization Code with PKCE** for web applications
* **Client Credentials** for service-to-service communication

## Extending This Demo

* Replace test users with ASP.NET Core Identity
* Store clients in a database using `IClientStore`
* Add refresh token support
* Implement role-based authorization using token claims
* Use environment-specific configuration for production

## Learn More

* **[Full Tutorial on DEV.to](https://dev.to/karnafun/building-an-oauth2-protected-api-with-c-identityserver-and-aspnet-core-23g2)** - Detailed explanation with code walkthrough
* [Duende IdentityServer Documentation](https://docs.duendesoftware.com/identityserver)
* [OAuth 2.0 Specification](https://oauth.net/2/)
* [JWT.io](https://jwt.io/) - Decode and inspect tokens

## License

This project is provided as-is for educational purposes.

---
**Questions or issues?** Open an issue or check the [DEV.to tutorial](https://dev.to/karnafun/building-an-oauth2-protected-api-with-c-identityserver-and-aspnet-core-23g2) for detailed explanations.

Looking for help building secure APIs? [Hire me](https://www.fiverr.com/s/NNKV0VG)  
*Backend engineer & API integrator. Building secure, scalable APIs with .NET.*

