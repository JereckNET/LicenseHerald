using System;
using System.Reflection;
using JereckNET.LicenseHerald;

namespace TestConsumer {
    class Program {
        static void Main(string[] args) {
            var producer = new TestProducer.Producer();

            var components = Assembly.GetExecutingAssembly().GetLicensedComponent();

            foreach (LicensedComponent component in components) {
                Console.WriteLine(component.Name);
                Console.WriteLine(component.Version);
                Console.WriteLine(component.HomePage);
                Console.WriteLine(component.License);
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
