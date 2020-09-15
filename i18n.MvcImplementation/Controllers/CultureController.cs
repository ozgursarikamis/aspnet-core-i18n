using System;
using System.Globalization;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace i18n.MvcImplementation.Controllers
{
    public class CultureController : Controller
    {
        [HttpPost]
        public IActionResult Set(string uiCulture, string returnUrl)
        {
            var languages = Request.GetTypedHeaders()
                .AcceptLanguage
                ?.OrderByDescending(x => x.Quality ?? 1) // Quality defines priority from 0 to 1, where 1 is the highest.
                .Select(x => x.Value.ToString())
                .ToArray() ?? Array.Empty<string>();

            IRequestCultureFeature feature = HttpContext.Features.Get<IRequestCultureFeature>();
            RequestCulture requestCulture = 
                new RequestCulture(feature.RequestCulture.Culture, new CultureInfo(uiCulture));

            string cookieValue = CookieRequestCultureProvider.MakeCookieValue(requestCulture);
            string cookieName = CookieRequestCultureProvider.DefaultCookieName;

            Response.Cookies.Append(cookieName, cookieValue);

            return LocalRedirect(returnUrl);
        }
    }
}
