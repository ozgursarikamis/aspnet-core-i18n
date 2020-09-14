using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;

namespace i18n.Middlewares.Localization
{
    public class CountryDomainRequestCultureProvider : IRequestCultureProvider
    {
        public Task<ProviderCultureResult> DetermineProviderCultureResult(
            HttpContext httpContext)
        {
            ProviderCultureResult result = null;

            var map = new Dictionary<string, string>
            {
                {"ba", "bs"},
                {"es", "es"},
                {"de", "de"},
                {"fr", "fr-FR"}
            };

            string domain = httpContext.Request.Host.Host.Split('.').Last();

            if (map.ContainsKey(domain))
            {
                result = new ProviderCultureResult(map[domain]);
            }

            return Task.FromResult(result);
        }
    }
}
