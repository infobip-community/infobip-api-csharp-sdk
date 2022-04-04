using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Infobip.Api.SDK.WebRtc.Models;
using Infobip.Api.SDK.WhatsApp.Models;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.Example
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            using IHost host = CreateHostBuilder(args).Build();

            await SendWhatsAppTextMessage();

            await MakeSomeApiCalls();
        }

        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args);

        public static async Task<WhatsAppSingleMessageInfoResponse> SendWhatsAppTextMessage()
        {
            var configuration = new ApiClientConfiguration(
                "https://XYZ.api.infobip.com",
                "YOUR_API_KEY_FROM_PORTAL");

            var client = new InfobipApiClient(configuration);

            var request = new WhatsAppTextMessageRequest
            {
                From = "FROM_NUMBER",
                To = "TO_NUMBER",
                MessageId = "MESSAGE_ID",
                Content = new WhatsAppTextContent("Message Text!")
            };
            return await client.WhatsApp.SendWhatsAppTextMessage(request);
        }

        private static async Task MakeSomeApiCalls()
        {
            var configuration = new ApiClientConfiguration(
                "https://XYZ.api.infobip.com",
                "YOUR_API_KEY_FROM_PORTAL");

            var infobipClient = new InfobipApiClient(configuration);

            // WebRtc.GetWebRtcApplications
            var getWebRtcApplicationsResponse = await infobipClient.WebRtc.GetWebRtcApplications();
            getWebRtcApplicationsResponse.DumpToConsole("getWebRtcApplicationsResponse");

            // WebRtc.GenerateWebRtcToken
            var generateWebRtcTokenResponse = await infobipClient.WebRtc.GenerateWebRtcToken(new WebRtcTokenRequest("MyIdentity", getWebRtcApplicationsResponse.FirstOrDefault()?.Id ?? Guid.NewGuid().ToString()));
            generateWebRtcTokenResponse.DumpToConsole("generateWebRtcTokenResponse");

            // WhatsApp.SendWhatsAppTextMessage
            var sendWhatsAppTextMessageResponse = await infobipClient.WhatsApp.SendWhatsAppTextMessage(new WhatsAppTextMessageRequest("from", "to_number",Guid.NewGuid().ToString(), new WhatsAppTextContent("Message text...")), CancellationToken.None);
            sendWhatsAppTextMessageResponse.DumpToConsole("sendWhatsAppTextMessageResponse");

            // WhatsApp.GetWhatsappTemplates
            var getWhatsAppTemplatesResponse = await infobipClient.WhatsApp.GetWhatsAppTemplates("sender", CancellationToken.None);
            getWhatsAppTemplatesResponse.DumpToConsole("getWhatsAppTemplatesResponse");

            // Just use InfobipApiClient instance to call desired API endpoint.
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
