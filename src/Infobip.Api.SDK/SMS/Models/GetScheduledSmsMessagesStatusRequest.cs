using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.SMS.Models
{
    /// <summary>
    /// GetScheduledSmsMessagesStatusRequest
    /// </summary>
    public class GetScheduledSmsMessagesStatusRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetScheduledSmsMessagesStatusRequest" /> class.
        /// </summary>
        [JsonConstructor]
        protected GetScheduledSmsMessagesStatusRequest() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetScheduledSmsMessagesRequest" /> class.
        /// </summary>
        /// <param name="bulkId">BulkId</param>
        public GetScheduledSmsMessagesStatusRequest(string bulkId)
        {
            BulkId = bulkId;
        }

        /// <summary>
        /// Gets or Sets BulkId
        /// </summary>
        [JsonProperty("bulkId")]
        [Required]
        public string BulkId { get; set; }
    }
}
