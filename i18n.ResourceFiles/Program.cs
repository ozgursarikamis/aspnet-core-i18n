using System;
using System.Globalization;
using System.Resources;
using i18n.ResourceFiles.Resources;

namespace i18n.ResourceFiles
{
    internal class Program
    {
        private static void Main()
        {
            // Console.WriteLine(HomePage.Welcome);

            var manager = new ResourceManager(typeof(HomePage));

            // option 1:
            var welcomeMessage = manager.GetString("Welcome");
            Console.WriteLine(welcomeMessage);

            // option 2:
            var ci = new CultureInfo("de-DE");
            var welcomeMessageDe = manager.GetString("Welcome", ci);
            Console.WriteLine(welcomeMessageDe);
        }
    }
}
