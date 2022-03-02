using System.Net.Http;
using Infobip.Api.SDK.RCS;
using Infobip.Api.SDK.WebRtc;
using Infobip.Api.SDK.WhatsApp;

namespace Infobip.Api.SDK
{
    /// <inheritdoc />
    public sealed class InfobipApiClient : IInfobipApiClient
    {
        public InfobipApiClient(HttpClient client)
        {
            WhatsApp = new WhatsAppClient(client);
            Rcs = new Rcs(client);
            WebRtc = new WebRtcClient(client);
        }

        /// <inheritdoc />
        public IWhatsApp WhatsApp { get; }

        /// <inheritdoc />
        public IRcs Rcs { get; }

        /// <inheritdoc />
        public IWebRtc WebRtc { get; }
    }
}