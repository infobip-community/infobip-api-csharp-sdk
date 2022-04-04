using Newtonsoft.Json;

namespace Infobip.Api.SDK.MMS.Models
{
    /// <summary>
    /// SendMmsMessageResponseDetails
    /// </summary>
    public class SendMmsMessageResponseDetails
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SendMmsMessageResponseDetails" /> class.
        /// </summary>
        [JsonConstructor]
        public SendMmsMessageResponseDetails() { }

        /// <summary>
        /// The message destination address.
        /// </summary>
        [JsonProperty("to")]
        public string To { get; set; }

        /// <summary>
        /// Indicates whether the message is successfully sent, not sent, delivered, not delivered, waiting for delivery or any other possible status.
        /// </summary>
        [JsonProperty("status")]
        public SendMmsMessageResponseDetailsStatus Status { get; set; }


        /// <summary>
        /// The ID that uniquely identifies the message sent.
        /// </summary>
        [JsonProperty("messageId")]
        public string MessageId { get; set; }
    }
}