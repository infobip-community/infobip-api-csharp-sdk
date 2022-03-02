using System.Net.Http;
using Infobip.Api.Client.RCS;
using Infobip.Api.Client.WebRtc;
using Infobip.Api.Client.WhatsApp;

namespace Infobip.Api.Client
{
    /// <inheritdoc />
    public sealed class InfobipApiClient : IInfobipApiClient
    {
        public InfobipApiClient(HttpClient client)
        {
            WhatsApp = new WhatsApp.WhatsAppClient(client);
            Rcs = new RCS.RcsClient(client);
            WebRtc = new WebRtc.WebRtcClient(client);
        }

        /// <inheritdoc />
        public IWhatsApp WhatsApp { get; }

        /// <inheritdoc />
        public IRcs Rcs { get; }

        /// <inheritdoc />
        public IWebRtc WebRtc { get; }
    }
}