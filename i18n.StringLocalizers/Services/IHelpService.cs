using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.Localization;

namespace i18n.StringLocalizers.Services
{
    public interface IHelpService
    {
        string GetHelpFor(string serviceName);
    }

    public class HelpService : IHelpService
    {
        private readonly IStringLocalizerFactory _factory;

        public HelpService(IStringLocalizerFactory factory)
        {
            _factory = factory;
        }
        public string GetHelpFor(string serviceName)
        {
            var serviceClassName = $"{serviceName}Service";
            Type serviceType = Assembly.GetEntryAssembly()
                ?.ExportedTypes
                .FirstOrDefault(
                    x => x.Name.Equals(serviceClassName, StringComparison.CurrentCultureIgnoreCase)
                    );
            if (serviceType == null)
            {
                return $"Help is not abailable for {serviceName}";
            }

            IStringLocalizer localizer = _factory.Create(serviceType);

            IEnumerable<LocalizedString> resources = localizer.GetAllStrings();
            IEnumerable<string> keys = resources.Select(x => x.Name);

            return $"Available Keys: {string.Join(",", keys)}";
        }
    }
}