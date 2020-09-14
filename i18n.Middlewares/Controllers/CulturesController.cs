using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace i18n.Middlewares.Controllers
{
    public class CulturesController : ControllerBase
    {
        public IActionResult Set(string uiCulture)
        {
            RequestCulture requestCulture = new RequestCulture(uiCulture);

            string cookie = CookieRequestCultureProvider.MakeCookieValue(requestCulture);

            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName, cookie);

            return Ok();
        }
    }
}
