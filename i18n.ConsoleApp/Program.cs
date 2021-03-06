﻿using System;
using System.Globalization;
using System.Linq;
using System.Text;

namespace i18n.ConsoleApp
{
    internal class Program
    {
        private static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            DisplayDateAndTime();
            DisplayCurrentCulture();
            StringSortMethod();

            Console.WriteLine("============================= Change The Culture Info");
            var en = new CultureInfo("tr-TR");
            CultureInfo.CurrentCulture = en;

            DisplayDateAndTime();

            Console.WriteLine(CultureInfo.CurrentCulture);
            StringSortMethod();

            NumberParsingDemo();

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
            var date = DateTime.Parse(dateString, new CultureInfo("de-De"));
            Console.WriteLine(date.ToString("D"));
            Console.WriteLine("============================= DateTime Parse");
        }

        private static void StringSortMethod()
        {
            Console.WriteLine();
            Console.WriteLine("============================= StringSortMethod");

            string[] surnames =
            {
                "Zoltan", "Anderson", "Çelik", "Davis", "Şuayip", "Cooper"
            };
            foreach (var surname in surnames.OrderBy(x => x, StringComparer.Ordinal))
            {
                Console.WriteLine(surname);
            }
            Console.WriteLine("============================= StringSortMethod");
            Console.WriteLine();
        }

        private static void NumberParsingDemo()
        {
            const string numberAsString = "1,500";
            var number = decimal.Parse(numberAsString, new CultureInfo("en-GB")) + 1;
            Console.WriteLine(number);
            Console.WriteLine("{0:C}", number); // currency formatting
            Console.WriteLine(number.ToString("C", new CultureInfo("en-US"))); // always use US Dollar
            Console.WriteLine(number.ToString("C", new CultureInfo("de-DE"))); // always use €
        }
    }
}
