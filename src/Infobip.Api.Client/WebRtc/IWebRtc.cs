using System.Collections.Generic;
using System.Threading.Tasks;
using Infobip.Api.Client.WebRtc.Models;

namespace Infobip.Api.Client.WebRtc
{
    public interface IWebRtc
    {
        // WebRTC Token
        Task<WebRtcTokenResponse> GenerateWebRtcToken(WebRtcTokenRequest requestPayload);

        // WebRTC Applications
        Task<List<WebRtcApplicationResponse>> GetWebRtcApplications();
        Task<WebRtcApplicationResponse> SaveWebRtcApplication(WebRtcApplicationRequest requestPayload);
        Task<WebRtcApplicationResponse> GetWebRtcApplication(string id);
        Task<WebRtcApplicationResponse> UpdateWebRtcApplication(string id, WebRtcApplicationRequest requestPayload);
        Task DeleteWebRtcApplication(string id);
    }
}