using System;
using System.Globalization;

namespace i18n.ConsoleApp
{
    internal class Program
    {
        private static void Main()
        {
            var en = new CultureInfo("tr-TR");
            CultureInfo.CurrentCulture = en;
            Console.WriteLine(CultureInfo.CurrentCulture);
        }
    }
}
