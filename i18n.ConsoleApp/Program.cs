using System;
using System.Globalization;

namespace i18n.ConsoleApp
{
    internal class Program
    {
        private static void Main()
        {
            DisplayCurrentCulture();
            var en = new CultureInfo("tr-TR");
            CultureInfo.CurrentCulture = en;
            Console.WriteLine(CultureInfo.CurrentCulture);
        }

        private static void DisplayCurrentCulture()
        {
            Console.WriteLine("=============================");
            Console.WriteLine(CultureInfo.CurrentCulture.Name);
            Console.WriteLine(CultureInfo.CurrentCulture.DisplayName);
            Console.WriteLine("=============================");
        }
    }
}
