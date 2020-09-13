using System;
using System.Globalization;
using System.Reflection;
using System.Resources;
using i18n.Enumeration.Resources;

namespace i18n.Enumeration
{ internal class Program
    {
        private static void Main()
        {
            Console.WriteLine(Gender.Unspecified.ToString());

            CultureInfo.CurrentUICulture = new CultureInfo("de-DE");
            Console.WriteLine(Gender.Unspecified.ToLocalizedString());
        }
    }
    public class EnumResourceAttribute : Attribute
    {
        public Type ResourceType { get; set; }

        public EnumResourceAttribute(Type resourceType)
        {
            ResourceType = resourceType;
        }
    }

    [EnumResource(typeof(GenderEnumResource))]
    public enum Gender
    {
        Male, Female, Unspecified
    }

    public static class EnumExtensions
    {
        public static string ToLocalizedString(this Enum e)
        {
            var type = e.GetType();
            var typeInfo = type.GetTypeInfo();

            var attr = typeInfo.GetCustomAttribute<EnumResourceAttribute>();

            if (attr == null) return e.ToString();
            var manager = new ResourceManager(attr.ResourceType);
            return manager.GetString(e.ToString());
        }
    }
}
