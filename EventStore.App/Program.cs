using System;
using System.Net;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.CommandLine;

namespace EventStore.App
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Event Store settings up for Event Sourcing");

            try
            {
                var config = new ConfigurationBuilder()
                    .AddCommandLine(args)
                    .AddEnvironmentVariables()
                    .AddJsonFile("appsettings.json", true, true)
                    .Build();

                var builder = new WebHostBuilder()
                    .UseConfiguration(config)
                    .UseStartup<Startup>()
                    .UseKestrel(options => { options.Listen(IPAddress.Any, 80); });

                var host = builder.Build();
                host.Run();


            }
            catch (Exception e)
            {

            }
            finally
            {
                Console.WriteLine("Event store is UP now!!");
            }
        }
    }
}
