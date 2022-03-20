using System;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.Email.Models
{
    /// <summary>
    /// RescheduleEmailMessagesResponse
    /// </summary>
    public class RescheduleEmailMessagesResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RescheduleEmailMessagesResponse" /> class.
        /// </summary>
        [JsonConstructor]
        public RescheduleEmailMessagesResponse() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="RescheduleEmailMessagesResponse" /> class.
        /// </summary>
        /// <param name="bulkId">bulkId.</param>
        /// <param name="sendAt">sendAt.</param>
        public RescheduleEmailMessagesResponse(string bulkId = default, DateTime sendAt = default)
        {
            BulkId = bulkId;
            SendAt = sendAt;
        }

        /// <summary>
        /// Gets or Sets BulkId
        /// </summary>
        [JsonProperty("bulkId")]
        public string BulkId { get; set; }

        /// <summary>
        /// Gets or Sets SendAt
        /// </summary>
        [JsonProperty("sendAt")]
        public DateTime SendAt { get; set; }
    }
}
