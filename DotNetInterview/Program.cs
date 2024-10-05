using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetInterview
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddLogging(builder =>
            {
                builder.AddConsole();
            });

            // TODO: Register ApiService, RegistryService, and SoftwareReporter
            // in the ServiceCollection.
            var container = serviceCollection
                .AddSingleton<IApiService, ApiService> ()
                .AddSingleton<IRegistryService, RegistryService>()
                .AddSingleton<ISoftwareReporter, SoftwareReporter>()
                .BuildServiceProvider();

            // TODO: Retrieve an instance of SoftwareReporter from the
            // dependency injection container.
            var softwareReporter = container.GetRequiredService<ISoftwareReporter>();

            // TODO: Call ReportSoftwareInstallationStatus method, using "Syncro"
            // as the software name.
            foreach (var app in new[] { "Syncro", "Visual Studio" })
            {
                await softwareReporter.ReportSoftwareInstallationStatus(app);
            }

            Console.WriteLine("\nPress any key to exit.");
            Console.ReadKey();
        }
    }
}
