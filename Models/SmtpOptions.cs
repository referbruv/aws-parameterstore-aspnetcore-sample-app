using System.Collections.Generic;

namespace ParamStoreApp.Models
{
    public class SmtpOptions
    {
        public const string SectionName = "Smtp";
        public int Port { get; set; }
        public string From { get; set; }
        public string Server { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsSsl { get; set; }
    }

    public class OidcProviders
    {
        public const string Google = "Google";
        public const string Facebook = "Facebook";
        public const string Okta = "Okta";
    }

    public class OidcOptions
    {
        public const string SectionName = "Oidc";
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
    }

    public class ConfigOptions
    {
        public string AllowedUrls { get; set; }
    }
}