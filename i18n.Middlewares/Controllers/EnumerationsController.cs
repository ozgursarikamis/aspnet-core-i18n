using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using i18n.Middlewares.Enumerations;
using i18n.Middlewares.Localization;
using i18n.Middlewares.Models;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace i18n.Middlewares.Controllers
{
    [MiddlewareFilter(typeof(LocalizationPipeline))]
    public class EnumerationsController : ControllerBase
    {
        private readonly IStringLocalizer<Gender> _genderLocalizer;
        public EnumerationsController(IStringLocalizer<Gender> genderLocalizer)
        {
            _genderLocalizer = genderLocalizer;
        }

        public IActionResult Genders()
        {
            Debug.WriteLine("===========================");
            Debug.WriteLine($"Current Culture: { CultureInfo.CurrentCulture}");
            Debug.WriteLine($"Current UI Culture: { CultureInfo.CurrentUICulture}");
            Debug.WriteLine("===========================");
            
            List<SelectItem> selectList = new List<SelectItem>();

            Array values = Enum.GetValues(typeof(Gender));

            foreach (var value in values)
            {
                selectList.Add(new SelectItem
                {
                    Name = _genderLocalizer[value.ToString()],
                    Value = (int)value
                });
            }

            IRequestCultureFeature feature =
                HttpContext.Features.Get<IRequestCultureFeature>();

            Debug.WriteLine("===========================");
            Debug.WriteLine($"Culture: {feature.RequestCulture.Culture}");
            Debug.WriteLine($"UI Culture: {feature.RequestCulture.UICulture}");
            Debug.WriteLine($"Provider: {feature.Provider}");

            return Ok(selectList);
        }
    }
}
