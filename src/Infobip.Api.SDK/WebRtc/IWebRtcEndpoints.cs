using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Infobip.Api.SDK.WebRtc.Models;

namespace Infobip.Api.SDK.WebRtc
{
    /// <summary>
    /// Represents a collection of functions to interact with the WebRTC API endpoints.
    /// </summary>
    public interface IWebRtcEndpoints
    {
        // WebRTC Token
        /// <summary>
        /// Generate WebRTC Token.
        /// </summary>
        /// <remarks>
        /// This endpoint allows you to generate token for WebRTC channel.
        /// </remarks>
        /// <param name="requestPayload">Request payload.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.See <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> of <see cref="WebRtcTokenResponse"/>.</returns>
        Task<WebRtcTokenResponse> GenerateWebRtcToken(WebRtcTokenRequest requestPayload, CancellationToken cancellationToken = default);

        // WebRTC Applications
        /// <summary>
        /// Get WebRTC applications.
        /// </summary>
        /// <remarks>
        /// List all applications for WebRTC channel.
        /// </remarks>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.See <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> of List&lt;<see cref="WebRtcApplicationResponse"/>&gt;.</returns>
        Task<List<WebRtcApplicationResponse>> GetWebRtcApplications(CancellationToken cancellationToken = default);

        /// <summary>
        /// Save WebRTC application.
        /// </summary>
        /// <remarks>
        /// Create and configure a new WebRTC application.
        /// </remarks>
        /// <param name="requestPayload">Request payload.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.See <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> of <see cref="WebRtcApplicationResponse"/>.</returns>
        Task<WebRtcApplicationResponse> SaveWebRtcApplication(WebRtcApplicationRequest requestPayload, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get WebRTC application.
        /// </summary>
        /// <remarks>
        /// Get a single WebRTC application to see its configuration details.
        /// </remarks>
        /// <param name="id">Id of the application to get.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.See <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> of <see cref="WebRtcApplicationResponse"/>.</returns>
        Task<WebRtcApplicationResponse> GetWebRtcApplication(string id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Update WebRTC application
        /// </summary>
        /// <remarks>
        /// Change configuration details of your existing WebRTC application.
        /// </remarks>
        /// <param name="id">Id of the application to update.</param>
        /// <param name="requestPayload">Request payload.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.See <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> of <see cref="WebRtcApplicationResponse"/>.</returns>
        Task<WebRtcApplicationResponse> UpdateWebRtcApplication(string id, WebRtcApplicationRequest requestPayload, CancellationToken cancellationToken = default);

        /// <summary>
        /// Delete WebRTC application.
        /// </summary>
        /// <remarks>
        /// Delete WebRTC application for a given id.
        /// </remarks>
        /// <param name="id">Id of the application to delete.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.See <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/>.</returns>
        Task DeleteWebRtcApplication(string id, CancellationToken cancellationToken = default);
    }
}