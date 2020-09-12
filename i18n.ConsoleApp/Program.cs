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

            Console.WriteLine("============================= Change The Culture Info");
            var en = new CultureInfo("tr-TR");
            CultureInfo.CurrentCulture = en;

            DisplayDateAndTime();

            Console.WriteLine(CultureInfo.CurrentCulture);

            DateTimeParseDemo();
        }

        private static void DisplayCurrentCulture()
        {
            Console.WriteLine("============================= Display The Culture Info");
            Console.WriteLine(CultureInfo.CurrentCulture.Name);
            Console.WriteLine(CultureInfo.CurrentCulture.DisplayName); 
        }

        private static void DisplayDateAndTime()
        {
            Console.WriteLine("============================= Display DateTime Info");
            Console.WriteLine(DateTime.Now);
        }

        private static void DateTimeParseDemo()
        {
            Console.WriteLine("============================= DateTime Parse");
            const string dateString = "24.12.2016";
            var date = DateTime.Parse(dateString);
            Console.WriteLine(date.ToString("D"));
        }
    }
}
