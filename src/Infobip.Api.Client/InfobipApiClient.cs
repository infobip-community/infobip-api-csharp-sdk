using Infobip.Api.Client.RCS;
using Infobip.Api.Client.WebRtc;
using Infobip.Api.Client.WhatsApp;
using RestSharp;

namespace Infobip.Api.Client
{
    public sealed class InfobipApiClient : IInfobipApiClient
    {
        public InfobipApiClient(IRestClient client)
        {
            WhatsApp = new WhatsApp.WhatsApp(client);
            Rcs = new RCS.Rcs(client);
            WebRtc = new WebRtc.WebRtc(client);

        }

        public IWhatsApp WhatsApp { get; }
        public IRcs Rcs { get; }
        public IWebRtc WebRtc { get; }
    }
}