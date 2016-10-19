using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace Shariff.Backend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var kestrelConfig = new ConfigurationBuilder()
                       .SetBasePath(Directory.GetCurrentDirectory())
                       .AddJsonFile("hosting.json", optional: true)
                       .Build();

            var host = new WebHostBuilder()
                .UseKestrel()
                .UseConfiguration(kestrelConfig)
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }
}
