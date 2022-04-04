using Infobip.Api.SDK.Email;
using Infobip.Api.SDK.MMS;
using Infobip.Api.SDK.RCS;
using Infobip.Api.SDK.SMS;
using Infobip.Api.SDK.WebRtc;
using Infobip.Api.SDK.WhatsApp;

namespace Infobip.Api.SDK
{
    /// <summary>
    /// Exposes Infobip API endpoints
    /// </summary>
    public interface IInfobipApiClient
    {
        /// <summary>
        /// Exposes WhatsApp API endpoints
        /// </summary>
        IWhatsAppEndpoints WhatsApp { get; }

        /// <summary>
        /// Exposes RCS API endpoints
        /// </summary>
        IRcsEndpoints Rcs { get; }

        /// <summary>
        /// Exposes WebRTC API endpoints
        /// </summary>
        IWebRtcEndpoints WebRtc { get; }

        /// <summary>
        /// Exposes Email API endpoints
        /// </summary>
        IEmailEndpoints Email { get; }

        /// <summary>
        /// Exposes SMS API endpoints
        /// </summary>
        ISmsEndpoints Sms { get; }

        /// <summary>
        /// Exposes MMS API endpoints
        /// </summary>
        IMmsEndpoints Mms { get; }
    }
}