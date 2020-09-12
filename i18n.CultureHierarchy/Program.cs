using System;
using System.Globalization;

namespace i18n.CultureHierarchy
{
    internal class Program
    {
        private static void Main()
        {
            CultureInfo.CurrentCulture = new CultureInfo("en-US");
            Console.WriteLine($"Current Culture: {CultureInfo.CurrentCulture}");
            Console.WriteLine($"Is Neutral: {CultureInfo.CurrentCulture.IsNeutralCulture}");
            Console.WriteLine($"Parent Culture: {CultureInfo.CurrentCulture.Parent}"); //ietf code
            Console.WriteLine("============================================================");
        }
    }
}
