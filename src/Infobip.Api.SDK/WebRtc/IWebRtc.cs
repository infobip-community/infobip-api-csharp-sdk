using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Infobip.Api.SDK.WebRtc.Models;

namespace Infobip.Api.SDK.WebRtc
{
    public interface IWebRtc
    {
        // WebRTC Token
        Task<WebRtcTokenResponse> GenerateWebRtcToken(WebRtcTokenRequest requestPayload, CancellationToken cancellationToken);

        // WebRTC Applications
        Task<List<WebRtcApplicationResponse>> GetWebRtcApplications(CancellationToken cancellationToken);
        Task<WebRtcApplicationResponse> SaveWebRtcApplication(WebRtcApplicationRequest requestPayload, CancellationToken cancellationToken);
        Task<WebRtcApplicationResponse> GetWebRtcApplication(string id, CancellationToken cancellationToken);
        Task<WebRtcApplicationResponse> UpdateWebRtcApplication(string id, WebRtcApplicationRequest requestPayload, CancellationToken cancellationToken);
        Task DeleteWebRtcApplication(string id, CancellationToken cancellationToken);
    }
}