using Newtonsoft.Json;

namespace Infobip.Api.SDK.SMS.Models
{
    /// <summary>
    /// GetInboundSmsMessagesRequest
    /// </summary>
    public class GetInboundSmsMessagesRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetInboundSmsMessagesRequest" /> class.
        /// </summary>
        [JsonConstructor]
        protected GetInboundSmsMessagesRequest() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetInboundSmsMessagesRequest" /> class.
        /// </summary>
        /// <param name="limit">Maximum number of messages to be returned in a response. (optional)</param>
        public GetInboundSmsMessagesRequest(int limit = default)
        {
            Limit = limit;
        }

        /// <summary>
        /// Maximum number of messages to be returned in a response.
        /// </summary>
        [JsonProperty("limit")]
        public int Limit { get; set; }
    }
}
