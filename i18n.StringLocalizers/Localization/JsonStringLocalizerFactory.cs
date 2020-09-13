using System;
using System.Globalization;
using System.Reflection;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;

namespace i18n.StringLocalizers.Localization
{
    public class JsonStringLocalizerFactory : IStringLocalizerFactory
    {
        private readonly IOptions<JsonLocalizationOptions> _options;
        private readonly string _resourcesRelativePath;

        public JsonStringLocalizerFactory(IOptions<JsonLocalizationOptions> options)
        {
            _options = options;
            _resourcesRelativePath = options.Value?.ResourcePath ?? string.Empty;
        }
        public IStringLocalizer Create(string baseName, string location)
        {
            throw new NotImplementedException();
        }

        public IStringLocalizer Create(Type resourceSource)
        {
            TypeInfo typeInfo = resourceSource.GetTypeInfo();

            AssemblyName assemblyName = new AssemblyName(typeInfo.Assembly.FullName ?? string.Empty);

            var baseNameSpace = assemblyName.Name;
            var typeRelativeNamespace = string.Empty;

            if (baseNameSpace != null)
            {
                typeRelativeNamespace = typeInfo.FullName?.Substring(baseNameSpace.Length);
            }

            return new JsonStringLocalizer(_resourcesRelativePath, typeRelativeNamespace, CultureInfo.CurrentUICulture);
        }
    }
}
