using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Bunq.Sdk.Samples.Utils
{
    public class SampleRunner
    {
        public static void Main(string[] args)
        {
            if (args.Length <= 0) return;

            var sampleClassName = Path.GetFileNameWithoutExtension(args[0]);
            var sampleInstance = (ISample) MagicallyCreateInstance(sampleClassName);
            sampleInstance.Run();
        }

        private static object MagicallyCreateInstance(string className)
        {
            var assembly = Assembly.GetEntryAssembly();
            var type = assembly.GetTypes().First(t => t.Name == className);

            return Activator.CreateInstance(type);
        }
    }
}
