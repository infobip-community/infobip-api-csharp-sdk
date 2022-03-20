using System.Net.Http;
using Infobip.Api.SDK.Email;
using Infobip.Api.SDK.RCS;
using Infobip.Api.SDK.Validation;
using Infobip.Api.SDK.WebRtc;
using Infobip.Api.SDK.WhatsApp;

namespace Infobip.Api.SDK
{
    /// <inheritdoc />
    public sealed class InfobipApiClient : IInfobipApiClient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InfobipApiClient"/> class.
        /// </summary>
        /// <param name="client">An instance of the <see cref="HttpClient"/></param>
        /// <param name="requestValidator">An instance of the <see cref="IRequestValidator"/></param>
        public InfobipApiClient(HttpClient client, IRequestValidator requestValidator)
        {
            WhatsApp = new WhatsAppClient(client, requestValidator);
            Rcs = new Rcs(client, requestValidator);
            WebRtc = new WebRtcClient(client, requestValidator);
            Email = new EmailClient(client, requestValidator);
        }

        /// <inheritdoc />
        public IWhatsApp WhatsApp { get; }

        /// <inheritdoc />
        public IRcs Rcs { get; }

        /// <inheritdoc />
        public IWebRtc WebRtc { get; }

        /// <inheritdoc />
        public IEmail Email { get; }
    }
}