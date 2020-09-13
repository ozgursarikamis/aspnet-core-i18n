using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using Microsoft.Extensions.Localization;
using Newtonsoft.Json.Linq;

namespace i18n.StringLocalizers.Localization
{
    public class JsonLocalizationOptions
    {
        public string ResourcePath { get; set; } = string.Empty;
    }

    public class JsonStringLocalizer : IStringLocalizer
    {
        private readonly string _resourcesRelativePath;
        private readonly string _typeRelativeNamespace;
        private readonly CultureInfo _uiCulture;
        private JObject _resourceCache;

        public JsonStringLocalizer(
            string resourcesRelativePath,
            string typeRelativeNamespace, CultureInfo uiCulture)
        {
            _resourcesRelativePath = resourcesRelativePath;
            _typeRelativeNamespace = typeRelativeNamespace;
            _uiCulture = uiCulture;
        }

        JObject GetResource()
        {
            if (_resourceCache != null) return _resourceCache;
            var tag = _uiCulture.Name;
            var typeRelativePath = _typeRelativeNamespace.Replace(".", "/");
            var filePath = $"{_resourcesRelativePath}{typeRelativePath}/{tag}.json";

            var json = File.Exists(filePath)
                ? File.ReadAllText(filePath, Encoding.Unicode)
                : "{}";

            _resourceCache = JObject.Parse(json);

            return _resourceCache;
        }

        public LocalizedString this[string name] => this[name, null];

        public LocalizedString this[string name, params object[] arguments]
        {
            get
            {
                JObject resource = GetResource();
                var value = resource.Value<string>(name);

                bool resourceNotFound = string.IsNullOrWhiteSpace(value);
                if (resourceNotFound)
                {
                    value = name;
                }
                else
                {
                    if (arguments != null)
                    {
                        value = string.Format(value, arguments);
                    }
                }
                return new LocalizedString(name, value, resourceNotFound);
            }
        }

        public IEnumerable<LocalizedString> GetAllStrings(bool includeParentCultures)
        {
            JObject resources = GetResource();
            foreach (var pair in resources)
            {
                yield return new LocalizedString(pair.Key, pair.Value.Value<string>());
            }
        }

        public IStringLocalizer WithCulture(CultureInfo culture)
        {
            return new JsonStringLocalizer(_resourcesRelativePath, _typeRelativeNamespace, culture);
        }
    }
}
