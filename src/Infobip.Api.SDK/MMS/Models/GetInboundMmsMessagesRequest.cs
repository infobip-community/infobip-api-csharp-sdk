using Newtonsoft.Json;

namespace Infobip.Api.SDK.MMS.Models
{
    /// <summary>
    /// GetInboundMmsMessagesRequest
    /// </summary>
    public class GetInboundMmsMessagesRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetInboundMmsMessagesRequest" /> class.
        /// </summary>
        [JsonConstructor]
        protected GetInboundMmsMessagesRequest() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetInboundMmsMessagesRequest" /> class.
        /// </summary>
        /// <param name="limit">Maximum number of messages to be returned in a response. (optional)</param>
        public GetInboundMmsMessagesRequest(int limit = default)
        {
            Limit = limit;
        }

        /// <summary>
        /// Maximal number of delivery reports that will be returned.
        /// </summary>
        [JsonProperty("limit")]
        public int Limit { get; set; }
    }
}
