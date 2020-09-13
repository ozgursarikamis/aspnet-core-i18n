using System;
using System.Resources;
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

                using var stream = assembly.GetManifestResourceStream(name);
                using var resourceReader = new ResourceReader(stream ?? throw new InvalidOperationException());
                
                var enumerator = resourceReader.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    Console.WriteLine($@"{enumerator.Key}: {enumerator.Value}");
                }

                Console.WriteLine(@"------------------------------------------------------");
            }
        }
    }
}
