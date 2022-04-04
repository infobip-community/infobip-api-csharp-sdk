using System;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.SMS.Models
{
    /// <summary>
    /// ScheduledSmsMessagesStatusResponse
    /// </summary>
    public class ScheduledSmsMessagesStatusResponse
    {
        /// <summary>
        /// Unique ID assigned to the request if messaging multiple recipients or sending multiple messages via a single API request.
        /// </summary>
        [JsonProperty("bulkId")]
        public string BulkId { get; set; }

        /// <summary>
        /// The status of the message(s).
        /// </summary>
        [JsonProperty("status")]
        public SmsBulkStatus Status { get; set; }
    }
}
