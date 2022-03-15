using System.Collections.Generic;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.RCS.Models
{
    /// <summary>
    /// SendRscBulkMessagesRequest
    /// </summary>
    public class SendRscBulkMessagesRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SendRscBulkMessagesRequest" /> class.
        /// </summary>
        /// <param name="messages">messages.</param>
        public SendRscBulkMessagesRequest(List<SendRcsMessageRequest> messages = default)
        {
            Messages = messages;
        }

        /// <summary>
        /// Gets or Sets Messages
        /// </summary>
        [JsonProperty("messages")]
        public List<SendRcsMessageRequest> Messages { get; set; }
    }
}
