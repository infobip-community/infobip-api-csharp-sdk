using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.Email.Models
{
    /// <summary>
    /// GetEmailDeliveryReportsRequest
    /// </summary>
    public class GetEmailDeliveryReportsRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetEmailDeliveryReportsRequest" /> class.
        /// </summary>
        public GetEmailDeliveryReportsRequest()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetEmailDeliveryReportsRequest" /> class.
        /// </summary>
        /// <param name="bulkId">Bulk ID for which report is requested. (optional)</param>
        /// <param name="messageId">The ID that uniquely identifies the sent email. (optional)</param>
        /// <param name="limit">Maximum number of reports. (optional)</param>
        public GetEmailDeliveryReportsRequest(string bulkId = default, string messageId = default, int limit = default)
        {
            BulkId = bulkId;
            MessageId = messageId;
            Limit = limit;
        }

        /// <summary>
        /// Bulk ID for which report is requested.
        /// </summary>
        [JsonProperty("bulkId")]
        public string BulkId { get; }

        /// <summary>
        /// The ID that uniquely identifies the sent email.
        /// </summary>
        [JsonProperty("messageId")]
        public string MessageId { get; }

        /// <summary>
        /// Maximum number of reports.
        /// </summary>
        [JsonProperty("limit")]
        [Range(0, int.MaxValue)]
        public int Limit { get; }
    }
}