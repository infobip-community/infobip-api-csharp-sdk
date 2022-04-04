using Newtonsoft.Json;

namespace Infobip.Api.SDK.Email.Models
{
    /// <summary>
    /// SendEmailMessageInfo
    /// </summary>
    public class SendEmailMessageInfo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SendEmailMessageInfo" /> class.
        /// </summary>
        /// <param name="messageCount">MessageCount.</param>
        /// <param name="messageId">MessageId.</param>
        /// <param name="status">Status.</param>
        /// <param name="to">To.</param>
        public SendEmailMessageInfo(int messageCount = default, string messageId = default, SendEmailMessageInfoStatus status = default, string to = default)
        {
            MessageCount = messageCount;
            MessageId = messageId;
            Status = status;
            To = to;
        }

        /// <summary>
        /// Gets or Sets MessageCount
        /// </summary>
        [JsonProperty("messageCount")]
        public int MessageCount { get; set; }

        /// <summary>
        /// Gets or Sets MessageId
        /// </summary>
        [JsonProperty("messageId")]
        public string MessageId { get; set; }

        /// <summary>
        /// Gets or Sets Status
        /// </summary>
        [JsonProperty("status")]
        public SendEmailMessageInfoStatus Status { get; set; }

        /// <summary>
        /// Gets or Sets To
        /// </summary>
        [JsonProperty("to")]
        public string To { get; set; }
    }
}