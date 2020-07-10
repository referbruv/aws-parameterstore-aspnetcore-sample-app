using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using ParamStoreApp.Models;

namespace ParamStoreApp.Controllers
{
    [Route("api/[controller]")]
    public class ParamsController : ControllerBase
    {
        private readonly IOptions<SmtpOptions> _smtpOptions;
        private readonly IOptionsSnapshot<OidcOptions> _oidcOptions;
        private readonly IOptions<ConfigOptions> _configOptions;
        
        public ParamsController(IOptions<SmtpOptions> smtpOptions, 
        IOptionsSnapshot<OidcOptions> oidcOptions, 
        IOptions<ConfigOptions> configOptions)
        {
            _smtpOptions = smtpOptions;
            _oidcOptions = oidcOptions;
            _configOptions = configOptions;
        }

        [HttpGet, Route("smtp")]
        public SmtpOptions GetSmtpOptions()
        {
            return _smtpOptions.Value;
        }

        [HttpGet, Route("allowedhosts")]
        public string GetAllowedHosts()
        {
            return _configOptions.Value.AllowedUrls;
        }

        [HttpGet, Route("oidc/{id}")]
        public OidcOptions GetOidcOptions(string id)
        {
            return _oidcOptions.Get(id);
        }
    }
}