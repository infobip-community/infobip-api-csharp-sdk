using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Infobip.Api.Client.Extensions;
using Infobip.Api.Client.WebRtc.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;

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
            // WebRtc.GetWebRtcApplications
            var webRtcApplications = await infobipClient.WebRtc.GetWebRtcApplications(CancellationToken.None);
            webRtcApplications.DumpToConsole("WebRtcApplications");


            var webRtcToken = await infobipClient.WebRtc.GenerateWebRtcToken(new WebRtcTokenRequest("MyIdentity", webRtcApplications.FirstOrDefault()?.Id ?? Guid.NewGuid().ToString()), CancellationToken.None);
            webRtcToken.DumpToConsole("webRtcToken");

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
