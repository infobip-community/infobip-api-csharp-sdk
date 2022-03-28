using System.Collections.Generic;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.MMS.Models
{
    /// <summary>
    /// GetInboundMmsMessagesResponse
    /// </summary>
    public class GetInboundMmsMessagesResponse
    {
        /// <summary>
        ///  Initializes a new instance of the <see cref="GetInboundMmsMessagesResponse" /> class.
        /// </summary>
        [JsonConstructor]
        public GetInboundMmsMessagesResponse() { }

        /// <summary>
        /// Gets or Sets Results
        /// </summary>
        [JsonProperty("results")]
        public List<MmsInboundMessage> Results { get; set; }
    }
}