using System;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.SMS.Models
{
    /// <summary>
    /// ScheduledSmsMessagesResponse
    /// </summary>
    public class ScheduledSmsMessagesResponse
    {

        /// <summary>
        /// Unique ID assigned to the request if messaging multiple recipients or sending multiple messages via a single API request.
        /// </summary>
        [JsonProperty("bulkId")]
        public string BulkId { get; set; }

        /// <summary>
        /// Date and time when the message is to be sent. Used for scheduled SMS (see Scheduled SMS endpoints for more details). Has the following format: yyyy-MM-dd'T'HH:mm:ss.SSSZ.
        /// </summary>
        [JsonProperty("sendAt")]
        public DateTimeOffset SendAt { get; set; }
    }
}