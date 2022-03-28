using System.Threading;
using System.Threading.Tasks;
using Infobip.Api.SDK.MMS.Models;

namespace Infobip.Api.SDK.MMS
{
    /// <summary>
    /// Represents a collection of functions to interact with the MMS API endpoints.
    /// </summary>
    public interface IMmsEndpoints
    {
        // Send MMS
        /// <summary>
        /// Send single MMS message
        /// This method allows you to send single MMS message to one destination address.
        /// </summary>
        /// <param name="requestPayload">Request payload</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.See <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> of <see cref="SendMmsMessageResponse"/>.</returns>
        Task<SendMmsMessageResponse> SendSingleMmsMessage(SendMmsMessageRequest requestPayload, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get outbound MMS message delivery reports
        /// If you are for any reason unable to receive real time delivery reports on your endpoint, you can use this API method to learn if and when the message has been delivered to the recipient. Each request will return a batch of delivery reports - only once. The following API request will return only new reports that arrived since the last API request.
        /// </summary>
        /// <param name="requestPayload">Request payload</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.See <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> of <see cref="GetMmsDeliveryReportResponse"/>.</returns>
        Task<GetMmsDeliveryReportResponse> GetOutboundMmsMessageDeliveryReports(GetMmsDeliveryReportRequest requestPayload, CancellationToken cancellationToken = default);

        // Receive MMS
        /// <summary>
        /// Get inbound MMS messages
        /// If for some reason you are unable to receive incoming MMS at the endpoint of your choice in real time, you can use this API call to fetch messages. Each request will return a batch of received messages - only once. The following API request will return only new messages that arrived since the last API request.
        /// </summary>
        /// <param name="requestPayload">Request payload</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.See <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> of <see cref="GetInboundMmsMessagesResponse"/>.</returns>
        Task<GetInboundMmsMessagesResponse> GetInboundMmsMessages(GetInboundMmsMessagesRequest requestPayload, CancellationToken cancellationToken = default);
    }
}
