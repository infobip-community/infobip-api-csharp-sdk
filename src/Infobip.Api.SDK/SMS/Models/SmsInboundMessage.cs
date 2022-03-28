using System;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.SMS.Models
{
    /// <summary>
    /// SmsInboundMessage
    /// </summary>
    public class SmsInboundMessage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SmsInboundMessage" /> class.
        /// </summary>
        [JsonConstructor]
        public SmsInboundMessage() { }

        /// <summary>
        /// Custom callback data sent over the notifyUrl.
        /// </summary>
        [JsonProperty("callbackData")]
        public string CallbackData { get; set; }

        /// <summary>
        /// Content of the message without a keyword (if a keyword was sent).
        /// </summary>
        [JsonProperty("cleanText")]
        public string CleanText { get; set; }

        /// <summary>
        /// Sender ID that can be alphanumeric or numeric.
        /// </summary>
        [JsonProperty("from")]
        public string From { get; set; }

        /// <summary>
        /// Keyword extracted from the message content.
        /// </summary>
        [JsonProperty("keyword")]
        public string Keyword { get; set; }

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
        /// Indicates when the Infobip platform received the message. Has the following format: yyyy-MM-dd'T'HH:mm:ss.SSSZ.
        /// </summary>
        [JsonProperty("receivedAt")]
        public DateTimeOffset ReceivedAt { get; set; }

        /// <summary>
        /// The number of characters within a message
        /// </summary>
        [JsonProperty("smsCount")]
        public int SmsCount { get; set; }

        /// <summary>
        /// Full content of the message.
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