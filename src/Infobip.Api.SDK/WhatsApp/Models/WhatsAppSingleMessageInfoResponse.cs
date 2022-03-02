using Newtonsoft.Json;

namespace Infobip.Api.SDK.WhatsApp.Models
{
    /// <summary>
    /// WhatsAppSingleMessageInfoResponse
    /// </summary>
    public class WhatsAppSingleMessageInfoResponse
    {
        /// <summary>
        /// Message destination.
        /// </summary>
        /// <value>Message destination.</value>
        [JsonProperty("to")]
        public string To { get; set; }

        /// <summary>
        /// Number of messages required to deliver.
        /// </summary>
        /// <value>Number of messages required to deliver.</value>
        [JsonProperty("messageCount")]
        public int MessageCount { get; set; }

        /// <summary>
        /// The ID that uniquely identifies the message sent.
        /// </summary>
        /// <value>The ID that uniquely identifies the message sent.</value>
        [JsonProperty("messageId")]
        public string MessageId { get; set; }

        /// <summary>
        /// Gets or Sets Status
        /// </summary>
        [JsonProperty("status")]
        public WhatsAppSingleMessageStatus Status { get; set; }
    }
}