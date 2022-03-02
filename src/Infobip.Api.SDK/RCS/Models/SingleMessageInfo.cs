using Newtonsoft.Json;

namespace Infobip.Api.SDK.RCS.Models
{
    /// <summary>
    /// SingleMessageInfo
    /// </summary>
    public class SingleMessageInfo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SingleMessageInfo" /> class.
        /// </summary>
        /// <param name="to">Message destination..</param>
        /// <param name="messageCount">Number of messages required to deliver..</param>
        /// <param name="messageId">The ID that uniquely identifies the message sent..</param>
        /// <param name="status">status.</param>
        public SingleMessageInfo(string to = default, int messageCount = default, string messageId = default, SingleMessageStatus status = default)
        {
            To = to;
            MessageCount = messageCount;
            MessageId = messageId;
            Status = status;
        }

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
        public SingleMessageStatus Status { get; set; }
    }
}