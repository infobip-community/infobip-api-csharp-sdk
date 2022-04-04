using System;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.SMS.Models
{
    /// <summary>
    /// SmsLog
    /// </summary>
    public class SmsLog
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SmsLog" /> class.
        /// </summary>
        [JsonConstructor]
        public SmsLog() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SmsLog" /> class.
        /// </summary>
        /// <param name="error">An <see cref="SmsError"/>.</param>
        /// <param name="price">An <see cref="SmsError"/>.</param>
        /// <param name="status">An <see cref="SmsStatus"/>.</param>
        public SmsLog(SmsError error = default, SmsPrice price = default, SmsStatus status = default)
        {
            Error = error;
            Price = price;
            Status = status;
        }

        /// <summary>
        /// Unique ID assigned to the request if messaging multiple recipients or sending multiple messages via a single API request.
        /// </summary>
        [JsonProperty("bulkId")]
        public string BulkId { get; set; }

        /// <summary>
        /// Date and time when the Infobip services finished processing the message (i.e. delivered to the destination, delivered to the destination network, etc.). Has the following format: yyyy-MM-dd'T'HH:mm:ss.SSSZ.
        /// </summary>
        [JsonProperty("doneAt")]
        public DateTimeOffset DoneAt { get; set; }

        /// <summary>
        /// Gets or Sets Error
        /// </summary>
        [JsonProperty("error")]
        public SmsError Error { get; set; }

        /// <summary>
        /// Sender ID that can be alphanumeric or numeric.
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
        /// Gets or Sets Price
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
        /// Gets or Sets Status
        /// </summary>
        [JsonProperty("status")]
        public SmsStatus Status { get; set; }

        /// <summary>
        /// Content of the message being sent.
        /// </summary>
        [JsonProperty("text")]
        public string Text { get; set; }

        /// <summary>
        /// The destination address of the message.
        /// </summary>
        [JsonProperty("to")]
        public string To { get; set; }
    }
}