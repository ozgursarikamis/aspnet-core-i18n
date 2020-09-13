using System.Diagnostics;
using Microsoft.Extensions.Localization;

namespace i18n.StringLocalizers.Services
{
    internal interface IAboutService
    {
        string Reply(string searchTerm);
    }

    public class AboutService : IAboutService
    {
        private readonly IStringLocalizer<AboutService> _localizer;

        public AboutService(IStringLocalizer<AboutService> localizer)
        {
            _localizer = localizer;
            Debug.WriteLine(_localizer.GetType());
        }
        public string Reply(string searchTerm)
        {
            LocalizedString resource = _localizer[searchTerm];
            if (resource.ResourceNotFound)
            {
                return _localizer["help"].Value;
            }

            return resource;
        }
    }
}
