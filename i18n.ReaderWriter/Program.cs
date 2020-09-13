using System;
using System.Runtime.Loader;

namespace i18n.ReaderWriter
{
    internal class Program
    {
        private static void Main()
        {
            var path = AppContext.BaseDirectory + "\\de-DE\\i18n.ReaderWriter.resources.dll";
            var assembly = AssemblyLoadContext.Default.LoadFromAssemblyPath(path);

            var names = assembly.GetManifestResourceNames();
            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
        }
    }
}
