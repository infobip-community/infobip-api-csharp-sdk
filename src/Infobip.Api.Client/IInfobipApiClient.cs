using Infobip.Api.Client.RCS;
using Infobip.Api.Client.WebRtc;
using Infobip.Api.Client.WhatsApp;

namespace Infobip.Api.Client
{
    /// <summary>
    /// Expose Infobip API endpoints
    /// </summary>
    public interface IInfobipApiClient
    {
        /// <summary>
        /// Expose WhatsApp API endpoints
        /// </summary>
        IWhatsApp WhatsApp { get; }

        /// <summary>
        /// Expose RCS API endpoints
        /// </summary>
        IRcs Rcs { get; }

        /// <summary>
        /// Expose WebRTC API endpoints
        /// </summary>
        IWebRtc WebRtc { get; }
    }
}