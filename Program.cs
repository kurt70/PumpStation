using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace PumpStation
{
    public class Program
    {
        public static IConfiguration Configuration { get; set; }

        public static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .AddCommandLine(args);

            Configuration = builder.Build();

            var hostHeaders = Configuration["Hosts"]?.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            if (hostHeaders==null)
            {
                hostHeaders = new[] { "http://0.0.0.0:5000", "http://localhost:5000" };
            }

            var host = WebHost.CreateDefaultBuilder(args)
                .UseConfiguration(Configuration)
                .UseWebRoot("pumpstation")
                .ConfigureLogging((hostingContext, logging) =>
                 {
                     logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                     logging.AddConsole();
                     logging.AddDebug();
                 })
                 .UseUrls(hostHeaders)
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }

    }
}
