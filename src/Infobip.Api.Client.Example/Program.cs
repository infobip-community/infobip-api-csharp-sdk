using System;
using System.IO;
using System.Threading.Tasks;
using Infobip.Api.Client.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;

namespace Infobip.Api.Client.Example
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            using IHost host = CreateHostBuilder(args).Build();
            using var scope = host.Services.CreateScope();
            var infobipClient = scope.ServiceProvider.GetService<IInfobipApiClient>();

            await MakeApiCallExample(infobipClient);
            
            await host.RunAsync();
        }

        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    var env = hostingContext.HostingEnvironment;

                    config
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json", optional: false, true);
                })
                .ConfigureServices((hostingContext, services) =>
                {
                    services.AddInfobipClient(hostingContext.Configuration);
                });

        private static async Task MakeApiCallExample(IInfobipApiClient infobipClient)
        {
            var webRtcApplications = await infobipClient.WebRtc.GetWebRtcApplications();
            webRtcApplications.DumpToConsole("WebRtcApplications");

            // Just use infobipClient instance to call desired api endpoint.
        }
    }

    internal static class Extensions
    {
        internal static void DumpToConsole(this object obj, string message)
        {
            if (message != null)
            {
                Console.WriteLine(message);
            }

            Console.WriteLine(JsonConvert.SerializeObject(obj));
        }
    }

}
