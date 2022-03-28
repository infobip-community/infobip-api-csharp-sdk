using System;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.MMS.Models
{
    /// <summary>
    /// MmsInboundMessage
    /// </summary>
    public class MmsInboundMessage
    {
        /// <summary>
        ///  Initializes a new instance of the <see cref="MmsInboundMessage" /> class.
        /// </summary>
        [JsonConstructor]
        public MmsInboundMessage() { }

        /// <summary>
        /// The ID that uniquely identifies the received message.
        /// </summary>
        [JsonProperty("messageId")]
        public string MessageId { get; set; }

        /// <summary>
        /// The message destination address.
        /// </summary>
        [JsonProperty("to")]
        public string To { get; set; }

        /// <summary>
        /// Sender ID that can be alphanumeric or numeric.
        /// </summary>
        [JsonProperty("from")]
        public string From { get; set; }

        /// <summary>
        /// Full text of the received message.
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }

        /// <summary>
        /// Tells when Infobip platform received the message. It has the following format: `yyyy-MM-dd'T'HH:mm:ss.SSSZ
        /// </summary>
        [JsonProperty("receivedAt")]
        public DateTimeOffset ReceivedAt { get; set; }

        /// <summary>
        /// The number of sent message segments.
        /// </summary>
        [JsonProperty("mmsCount")]
        public int MmsCount { get; set; }

        /// <summary>
        /// Custom callback data can be inserted during the setup phase.
        /// </summary>
        [JsonProperty("callbackData")]
        public string CallbackData { get; set; }
        
        /// <summary>
        /// Gets or Sets Price
        /// </summary>
        [JsonProperty("price")]
        public MmsPrice Price { get; set; }
    }
}