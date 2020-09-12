using System;
using System.Globalization;

namespace i18n.ConsoleApp
{
    internal class Program
    {
        private static void Main()
        {
            DisplayDateAndTime();
            DisplayCurrentCulture();
            var en = new CultureInfo("tr-TR");
            CultureInfo.CurrentCulture = en;
            DisplayDateAndTime();

            Console.WriteLine(CultureInfo.CurrentCulture);
        }

        private static void DisplayCurrentCulture()
        {
            Console.WriteLine("=============================");
            Console.WriteLine(CultureInfo.CurrentCulture.Name);
            Console.WriteLine(CultureInfo.CurrentCulture.DisplayName);
            Console.WriteLine("=============================");
        }

        private static void DisplayDateAndTime()
        {
            Console.WriteLine(DateTime.Now);
        }
    }
}
