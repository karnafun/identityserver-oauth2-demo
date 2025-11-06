using System.ComponentModel.DataAnnotations;

namespace ApiDemo.Configuration;

public class IdentityServerOptions
{
    public const string SectionName = "IdentityServer";

    [Required(ErrorMessage = "IdentityServer:Authority configuration value is required.")]
    public string Authority { get; set; } = string.Empty;
}

