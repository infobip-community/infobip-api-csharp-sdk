using Infobip.Api.SDK.Email;
using Infobip.Api.SDK.RCS;
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
        IWhatsApp WhatsApp { get; }

        /// <summary>
        /// Exposes RCS API endpoints
        /// </summary>
        IRcs Rcs { get; }

        /// <summary>
        /// Exposes WebRTC API endpoints
        /// </summary>
        IWebRtc WebRtc { get; }

        /// <summary>
        /// Exposes Email API endpoints
        /// </summary>
        IEmail Email { get; }
    }
}