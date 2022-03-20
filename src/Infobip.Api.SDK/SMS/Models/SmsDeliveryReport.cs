using System;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.SMS.Models
{
    /// <summary>
    /// SmsDeliveryReport
    /// </summary>
    public class SmsDeliveryReport
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="SmsDeliveryReport" /> class.
        /// </summary>
        [JsonConstructor]
        public SmsDeliveryReport() { }

        /// <summary>
        /// Unique ID assigned to the request if messaging multiple recipients or sending multiple messages via a single API request.
        /// </summary>
        [JsonProperty("bulkId")]
        public string BulkId { get; set; }

        /// <summary>
        /// Custom data sent over to the notifyUrl.
        /// </summary>
        [JsonProperty("callbackData")]
        public string CallbackData { get; set; }

        /// <summary>
        /// Date and time when the Infobip services finished processing the message (i.e., delivered to the destination, delivered to the destination network, etc.). Has the following format: yyyy-MM-dd'T'HH:mm:ss.SSSZ.
        /// </summary>
        [JsonProperty("doneAt")]
        public DateTimeOffset DoneAt { get; set; }

        /// <summary>
        /// Indicates whether an error occurred during the query execution.
        /// </summary>
        [JsonProperty("error")]
        public SmsError Error { get; set; }

        /// <summary>
        /// The sender ID which can be alphanumeric or numeric (e.g., CompanyName).
        /// </summary>
        [JsonProperty("from")]
        public string From { get; set; }

        /// <summary>
        /// Mobile country and network codes.
        /// </summary>
        [JsonProperty("mccMnc")]
        public string MccMnc { get; set; }

        /// <summary>
        /// Unique message ID.
        /// </summary>
        [JsonProperty("messageId")]
        public string MessageId { get; set; }

        /// <summary>
        /// Sent SMS price.
        /// </summary>
        [JsonProperty("price")]
        public SmsPrice Price { get; set; }

        /// <summary>
        /// Date and time when the message was [scheduled](https://www.infobip.com/docs/api#channels/sms/get-scheduled-sms-messages) to be sent. Has the following format: yyyy-MM-dd'T'HH:mm:ss.SSSZ.
        /// </summary>
        [JsonProperty("sentAt")]
        public DateTimeOffset SentAt { get; set; }

        /// <summary>
        /// The number of parts the message content was split into.
        /// </summary>
        [JsonProperty("smsCount")]
        public int SmsCount { get; set; }

        /// <summary>
        /// Indicates the status of the message and how to recover from an error should there be any.
        /// </summary>
        [JsonProperty("status")]
        public SmsStatus Status { get; set; }
    }
}