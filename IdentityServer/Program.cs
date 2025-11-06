using IdentityServer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddIdentityServer()
    .AddInMemoryClients(Config.Clients)
    .AddInMemoryApiScopes(Config.ApiScopes)
    .AddInMemoryApiResources(Config.ApiResources)
    .AddDeveloperSigningCredential()
    .AddTestUsers(Users.Get());

var app = builder.Build();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseIdentityServer();
app.Run();