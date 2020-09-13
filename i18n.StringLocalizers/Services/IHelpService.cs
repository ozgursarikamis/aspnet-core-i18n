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
        private readonly IStringLocalizer<DepartmentService> _departmentLocalizer;

        public HelpService(IStringLocalizer<AboutService> aboutLocalizer, IStringLocalizer<DepartmentService> departmentLocalizer)
        {
            _aboutLocalizer = aboutLocalizer;
            _departmentLocalizer = departmentLocalizer;
        }
        public string GetHelpFor(string serviceName)
        {
            IEnumerable<LocalizedString> resources;

            switch (serviceName)
            { 
                case "about":
                {
                    resources = _aboutLocalizer.GetAllStrings();
                    break;
                }
                case "department":
                {
                    resources = _departmentLocalizer.GetAllStrings();
                    break;
                }
                default:
                {
                    return $"Help was not found for {serviceName}";
                }
            }
            IEnumerable<string> keys = resources.Select(x => x.Name);

            return $"Available Keys: {string.Join(",", keys)}";
        }
    }
}