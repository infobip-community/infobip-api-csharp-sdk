using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.SMS.Models
{

    /// <summary>
    /// GetSmsDeliveryReportRequest
    /// </summary>
    public class GetSmsDeliveryReportRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetSmsDeliveryReportRequest" /> class.
        /// </summary>
        [JsonConstructor]
        protected GetSmsDeliveryReportRequest() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetSmsDeliveryReportRequest" /> class.
        /// </summary>
        /// <param name="bulkId">Unique ID assigned to the request if messaging multiple recipients or sending multiple messages via a single API request. (optional)</param>
        /// <param name="messageId">Unique message ID for which a report is requested.. (optional)</param>
        /// <param name="limit">Maximum number of delivery reports to be returned. (optional)</param>
        public GetSmsDeliveryReportRequest(string bulkId = default, string messageId = default, int limit = default)
        {
            BulkId = bulkId;
            MessageId = messageId;
            Limit = limit;
        }

        /// <summary>
        /// Unique ID assigned to the request if messaging multiple recipients or sending multiple messages via a single API request.
        /// </summary>
        [JsonProperty("bulkId")]
        public string BulkId { get; set; }

        /// <summary>
        /// Unique message ID for which a report is requested.
        /// </summary>
        [JsonProperty("messageId")]
        public string MessageId { get; set; }

        /// <summary>
        /// Maximum number of delivery reports to be returned.
        /// </summary>
        [JsonProperty("limit")]
        [Range(0, int.MaxValue)]
        public int Limit { get; set; }
    }
}
