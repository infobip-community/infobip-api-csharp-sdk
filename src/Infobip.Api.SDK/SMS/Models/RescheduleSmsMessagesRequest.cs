using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.SMS.Models
{
    /// <summary>
    /// RescheduleSmsMessagesRequest
    /// </summary>
    public class RescheduleSmsMessagesRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RescheduleSmsMessagesRequest" /> class.
        /// </summary>
        [JsonConstructor]
        protected RescheduleSmsMessagesRequest() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="RescheduleSmsMessagesRequest" /> class.
        /// </summary>
        /// <param name="bulkId">Unique ID assigned to the request if messaging multiple recipients or sending multiple messages via a single API request.</param>
        /// <param name="sendAt">Date and time when the message is to be sent. Used for scheduled SMS (see Scheduled SMS endpoints for more details). Has the following format: yyyy-MM-dd'T'HH:mm:ss.SSSZ.</param>
        public RescheduleSmsMessagesRequest(string bulkId = default, DateTimeOffset? sendAt = default)
        {
            BulkId = bulkId ?? throw new ArgumentNullException(nameof(bulkId));
            SendAt = sendAt ?? throw new ArgumentNullException(nameof(sendAt));
        }

        /// <summary>
        /// Unique ID assigned to the request if messaging multiple recipients or sending multiple messages via a single API request.
        /// </summary>
        [JsonIgnore]
        [Required]
        public string BulkId { get; set; }

        /// <summary>
        /// Date and time when the message is to be sent. Used for scheduled SMS (see [Scheduled SMS endpoints](https://www.infobip.com/docs/api#channels/sms/get-scheduled-sms-messages) for more details). Has the following format: yyyy-MM-dd'T'HH:mm:ss.SSSZ.
        /// </summary>
        [JsonProperty("sendAt")]
        [Required]
        public DateTimeOffset SendAt { get; set; }
    }
}
