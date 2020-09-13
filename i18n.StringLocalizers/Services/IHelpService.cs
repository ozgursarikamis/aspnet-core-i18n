using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Localization;

namespace i18n.StringLocalizers.Services
{
    public interface IHelpService
    {
        string GetHelpFor(string serviceName);
    }

    public class HelpService : IHelpService
    {
        private readonly IStringLocalizer<AboutService> _aboutLocalizer;

        public HelpService(IStringLocalizer<AboutService> aboutLocalizer)
        {
            _aboutLocalizer = aboutLocalizer;
        }
        public string GetHelpFor(string serviceName)
        {
            switch (serviceName)
            {
                case "about":
                {
                    IEnumerable<LocalizedString> resources = _aboutLocalizer.GetAllStrings();
                    IEnumerable<string> keys = resources.Select(x => x.Name);

                    return $"Available Keys: {string.Join(",", keys)}";
                }
                default:
                {
                    return $"Help was not found for {serviceName}";
                }
            }
        }
    }
}