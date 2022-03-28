using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.MMS.Models
{
    /// <summary>
    /// GetMmsDeliveryReportRequest
    /// </summary>
    public class GetMmsDeliveryReportRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetMmsDeliveryReportRequest" /> class.
        /// </summary>
        [JsonConstructor]
        protected GetMmsDeliveryReportRequest() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetMmsDeliveryReportRequest" /> class.
        /// </summary>
        /// <param name="bulkId">ID of bulk which delivery report is requested. (optional)</param>
        /// <param name="messageId">ID of MMS which delivery report is requested. (optional)</param>
        /// <param name="limit">Maximal number of delivery reports that will be returned. (optional)</param>
        public GetMmsDeliveryReportRequest(string bulkId = default, string messageId = default, int limit = default)
        {
            BulkId = bulkId;
            MessageId = messageId;
            Limit = limit;
        }

        /// <summary>
        /// ID of bulk which delivery report is requested.
        /// </summary>
        [JsonProperty("bulkId")]
        public string BulkId { get; set; }

        /// <summary>
        /// ID of MMS which delivery report is requested.
        /// </summary>
        [JsonProperty("messageId")]
        public string MessageId { get; set; }

        /// <summary>
        /// Maximal number of delivery reports that will be returned.
        /// </summary>
        [JsonProperty("limit")]
        [Range(0, int.MaxValue)]
        public int Limit { get; set; }
    }
}
