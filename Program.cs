using System.Reflection;

namespace testingTest
{
    internal class Program
    {
        IUnrestrictedInterface apiProgram;
        static void Main(string[] args)
        {
            UnrestrictedInstance apiProgram = new()
            { 
                Name = "Test",
                Version = "1.0.0",
                SensitiveData = "hello this is my secret key"
            };

            // Create a proxy for the instance
            var proxy = DispatchProxy.Create<IUnrestrictedInterface, ObfuscatingProxy<IUnrestrictedInterface>>();
            ((ObfuscatingProxy<IUnrestrictedInterface>)proxy).Initialize(apiProgram, nameof(IUnrestrictedInterface.SensitiveData));

            // Use the proxy
            Console.WriteLine($"Name: {proxy.Name}");               // Outputs "Test"
            Console.WriteLine($"Version: {proxy.Version}");         // Outputs "1.0.0"
            Console.WriteLine($"SensitiveData: {proxy.SensitiveData}"); // Outputs null (obfuscated)
            Console.ReadKey();
        }
    }
}
