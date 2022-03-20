using System.Collections.Generic;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.SMS.Models
{
    /// <summary>
    /// GetInboundSmsMessagesResponse
    /// </summary>
    public class GetInboundSmsMessagesResponse
    {
        /// <summary>
        ///  Initializes a new instance of the <see cref="GetInboundSmsMessagesResponse" /> class.
        /// </summary>
        [JsonConstructor]
        public GetInboundSmsMessagesResponse() { }

        /// <summary>
        /// The number of messages returned in the results array.
        /// </summary>
        [JsonProperty("messageCount")]
        public int MessageCount { get; set; }

        /// <summary>
        /// The number of messages that have not been pulled in.
        /// </summary>
        [JsonProperty("pendingMessageCount")]
        public int PendingMessageCount { get; set; }

        /// <summary>
        /// Gets or Sets Results
        /// </summary>
        [JsonProperty("results")]
        public List<SmsInboundMessage> Results { get; set; }
    }
}
