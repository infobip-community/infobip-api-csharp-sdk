using Infobip.Api.Client.RCS;
using Infobip.Api.Client.WebRtc;
using Infobip.Api.Client.WhatsApp;
using RestSharp;

namespace Infobip.Api.Client
{
    public interface IInfobipApiClient
    {
        IWhatsApp WhatsApp { get; }
        IRcs Rcs { get; }
        IWebRtc WebRtc { get; }
    }
}