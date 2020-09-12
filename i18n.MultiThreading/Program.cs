using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;

namespace i18n.MultiThreading
{
    internal class Program
    {
        private static void Main()
        {
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("pt-BR");

            ThreadInfo();

            TaskFactory taskFactory = new TaskFactory();
            taskFactory.StartNew(BackgroundTask);
            Task.Delay(3000).Wait();

            CultureInfo.CurrentCulture = new CultureInfo("ru-RU");
            ThreadInfo();
            Task.Delay(3000).Wait();
        }

        private static void ThreadInfo()
        {
            Console.WriteLine("======================================= ThreadInfo");
            Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} : {CultureInfo.CurrentCulture.DisplayName}");
            Console.WriteLine("======================================= ThreadInfo");
        }

        private static void BackgroundTask()
        {
            while (true)
            {
                ThreadInfo();
                Task.Delay(1000).Wait();
            }
        }
    }
}
