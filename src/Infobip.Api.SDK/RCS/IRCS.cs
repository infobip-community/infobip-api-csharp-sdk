using System.Threading;
using System.Threading.Tasks;
using Infobip.Api.SDK.RCS.Models;

namespace Infobip.Api.SDK.RCS
{
    /// <summary>
    /// Represents a collection of functions to interact with the RCS API endpoints
    /// </summary>
    public interface IRcs
    {
        /// <summary>
        /// Send RCS message
        /// </summary>
        /// <remarks>
        /// Used for sending single RCS messages
        /// </remarks>
        /// <param name="requestPayload">Request payload</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.See <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> of <see cref="RcsMessageResponse"/>.</returns>
        Task<RcsMessageResponse> SendRcsMessage(SendRcsMessageRequest requestPayload, CancellationToken cancellationToken);

        /// <summary>
        /// Send bulk RCS message
        /// </summary>
        /// <remarks>
        /// Used for sending bulk RCS messages
        /// </remarks>
        /// <param name="requestPayload">Request payload</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.See <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> of <see cref="RcsMessageResponse"/>.</returns>
        Task<RcsMessageResponse> SendBulkRcsMessages(SendRscBulkMessagesRequest requestPayload, CancellationToken cancellationToken);
    }
}